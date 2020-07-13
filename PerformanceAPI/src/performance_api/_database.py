from twisted.enterprise import adbapi
from performance_api._investment import Investment, Summary
from performance_api._exception import NotFound
from typing import List


def enable_fk_pragma(connection):
    """
    by default sqlite does not enable foreign keys, enable them here
    in a connection callback
    """
    cursor = connection.cursor()
    cursor.execute("PRAGMA foreign_keys = ON")

class InvestmentDatabase:
    def __init__(self, filename: str):
        self.db_pool = adbapi.ConnectionPool('sqlite3', filename,
                                             check_same_thread=False,
                                             cp_openfun=enable_fk_pragma)

    async def get_investments(self, account_id: int) -> List[Investment]:
        """
        return a list of Investment objects for a given account_id,
        raising a NotFound exception in the event the account does not
        exist
        """
        user_exists = await self.db_pool.runQuery("SELECT 1 FROM Account WHERE AccountId = ?",
                                                  (account_id,))
        if not user_exists:
            raise NotFound
        investments = await self.db_pool.runQuery(
            """SELECT Company.Name, InvestmentId
                 FROM Investment
                 JOIN Instrument USING (InstrumentId)
                 JOIN Company USING (CompanyId)
                WHERE AccountId = ?""", (account_id,))
        return [Investment(name, id) for (name, id) in investments]

    async def get_investment_detail(self, account_id: int, investment_id: int) -> Summary:
        """
        return an investment Summary object for a given account_id and
        investment_id, raises a NotFound exception in the event no
        records exist for the pair of IDs
        """
        query_result = await self.db_pool.runQuery(
            """WITH LatestPrice as (
             SELECT CompanyId, MAX(Timestamp), Price
               FROM Instrument
           GROUP BY CompanyId
           ), Purchase as (
           SELECT Company.Name as CompanyName,
                  Company.Symbol,
                  Company.CompanyId,
                  Investment.Quantity as Quantity,
                  Instrument.Price as Price,
                  Instrument.Timestamp
             FROM Investment
             JOIN Account USING (AccountId)
             JOIN Company ON (Company.CompanyId = Instrument.CompanyId)
             JOIN Instrument ON (Instrument.InstrumentId = Investment.InstrumentId)
             WHERE Investment.InvestmentId = ?
               AND Account.AccountId = ?
           ) SELECT Quantity,
                    Purchase.Price as CostBasis,
                    LatestPrice.Price as CurrentPrice,
                    (Quantity * LatestPrice.Price) as CurrentValue,
                    (LatestPrice.Price - Purchase.Price) as TotalGainLoss,
                    DATETIME('now') > DATETIME(Purchase.Timestamp, '+1 year') as IsLongTerm
               FROM Purchase
               JOIN LatestPrice USING (CompanyId)""", (investment_id, account_id))
        if not query_result:
            raise NotFound
        # query results are iterables of tuples, unpack to assign the
        # one result tuple here before constructing a dataclass
        result_tuple, *_ = query_result
        return Summary(*result_tuple)

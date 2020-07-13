from twisted.trial.unittest import SynchronousTestCase
from treq.testing import StubTreq
from performance_api import PerformanceAPI, Summary, Investment, NotFound


class DatabaseStub:
    """
    simple test double for database interactions, hardcodes several
    objects matching the type and format of the real thing, raising
    the same exception for cases where a value does not exist
    """
    def __init__(self, database_filename):
        pass

    async def get_investments(self, account_id):
        try:
            return {
                100 : [
                    Investment('foo', 123),
                    Investment('bar', 321)
                ],
                999 : []
            }[account_id]
        except KeyError:
            raise NotFound

    async def get_investment_detail(self, account_id, investment_id):
        try:
            return {
                456 : {123 : Summary(10, 20, 30, 300, 100, 0)}
            }[account_id][investment_id]
        except KeyError:
            raise NotFound

class PerformanceApiTests(SynchronousTestCase):
    """
    RFC 2606 requires the .invalid TLD be unused, so it is safe for
    tests to use it here where we are testing only the path portion of
    the URLs
    """
    def setUp(self):
        db = DatabaseStub('placehold-value-for-testing')
        self.client = StubTreq(PerformanceAPI(db).resource())

    def test_request_root(self):
        response = self.client.get('http://test.invalid/')
        result = self.successResultOf(response)
        self.assertEqual(result.code, 404)

    def test_investments_listing_response_code(self):
        response = self.client.get('http://test.invalid/user/100/investments')
        result = self.successResultOf(response)
        self.assertEqual(result.code, 200)

    def test_investments_listing_result_json(self):
        response = self.client.get(
            'http://test.invalid/user/100/investments'
        ).addCallback(lambda r: r.json())
        result = self.successResultOf(response)
        self.assertEqual(len(result), 2)
        self.assertEqual(result[0]['id'], 123)
        self.assertEqual(result[0]['name'], 'foo')
        self.assertEqual(result[1]['id'], 321)
        self.assertEqual(result[1]['name'], 'bar')

    def test_investments_listing(self):
        response = self.client.get('http://test.invalid/user/100/investments')
        result = self.successResultOf(response)
        self.assertEqual(result.code, 200)
        parsed_result = self.successResultOf(result.json())
        self.assertEqual(len(parsed_result), 2)
        self.assertEqual(parsed_result[0]['name'], 'foo')
        self.assertEqual(parsed_result[1]['id'], 321)

    def test_investments_listing_empty_result_response_code(self):
        response = self.client.get('http://test.invalid/user/999/investments')
        result = self.successResultOf(response)
        self.assertEqual(result.code, 200)

    def test_investments_listing_empty_result_json(self):
        response = self.client.get(
            'http://test.invalid/user/999/investments'
        ).addCallback(lambda r: r.json())
        result = self.successResultOf(response)
        self.assertEqual(len(result), 0)
        self.assertEqual(result, [])

    def test_investments_listing_no_such_account(self):
        response = self.client.get('http://test.invalid/user/333/investments')
        result = self.successResultOf(response)
        self.assertEqual(result.code, 404)

    def test_investments_summary_response_code(self):
        response = self.client.get('http://test.invalid/user/456/investments/123')
        result = self.successResultOf(response)
        self.assertEqual(result.code, 200)

    def test_investments_summary_result_json(self):
        response = self.client.get(
            'http://test.invalid/user/456/investments/123'
        ).addCallback(lambda r: r.json())
        result = self.successResultOf(response)
        self.assertEqual(result['numberOfShares'], 10)
        self.assertEqual(result['costBasis'], 20)
        self.assertEqual(result['currentPrice'], 30)
        self.assertEqual(result['currentValue'], 300)
        self.assertEqual(result['gainLoss'], 100)
        self.assertEqual(result['term'], 'short')

    def test_investments_summary_no_such_investment_response_code(self):
        response = self.client.get('http://test.invalid/user/456/investments/999')
        result = self.successResultOf(response)
        self.assertEqual(result.code, 404)

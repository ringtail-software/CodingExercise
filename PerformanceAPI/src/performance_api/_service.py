import json
from dataclasses import asdict
from klein import Klein, run
from performance_api._json_wrapper import Jsonify
from performance_api._database import InvestmentDatabase
from performance_api._exception import NotFound
from typing import List, Dict

class PerformanceAPI:
    _app = Klein()
    json_api = Jsonify(_app)
    def __init__(self, database):
        self.db = database

    # register an error handler for the custom exception and a top
    # level handler to return 404s as JSON
    @_app.handle_errors(NotFound)
    @_app.route('/<path:catchall>')
    def catchAll(self, request, catchall):
        request.setHeader('Content-Type', 'application/json')
        request.setResponseCode(404)
        return json.dumps('Not Found')

    def resource(self):
        """
        Accessor function to avoid reaching through the _app object when
        configuring the web server
        """
        return self._app.resource()

    @json_api.route('/user/<int:account_id>/investments')
    async def user_investments(self, request, account_id: int) -> List[Dict]:
        investments = await self.db.get_investments(account_id)
        return [asdict(i) for i in investments]

    @json_api.route('/user/<int:account_id>/investments/<int:investment_id>')
    async def investment_detail(self, request, account_id: int, investment_id: int) -> Dict:
        summary = await self.db.get_investment_detail(account_id, investment_id)
        return asdict(summary)

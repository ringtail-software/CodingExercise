from twisted import plugin
from twisted.application import service, strports
from twisted.python.usage import Options
from twisted.web.server import Site
from zope.interface import implementer
from performance_api import PerformanceAPI, InvestmentDatabase

class PerformanceApiOptions(Options):
    optParameters = [["listen", "l", "tcp:8080", "How to listen for requests"],
                     ["database", "d", "test.db", "sqlite database file"]]

@implementer(plugin.IPlugin, service.IServiceMaker)
class PerformanceApiServiceMaker(service.Service):
    tapname = "performance-api"
    description = "example API of investment data"
    options = PerformanceApiOptions

    def makeService(self, config):
        database = InvestmentDatabase(config['database'])
        performance_api = PerformanceAPI(database)
        factory = Site(performance_api.resource())
        return strports.service(config['listen'], factory)

makePerformanceApiService = PerformanceApiServiceMaker()

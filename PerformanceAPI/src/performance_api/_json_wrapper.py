from functools import wraps
from twisted.internet.defer import ensureDeferred
import json

class Jsonify(object):
    """
    Wrapper over the default Werkzeug router to default content-type
    headers and serialize response objects to JSON
    """
    def __init__(self, router):
        self.router = router

    def to_json(self, f):
        @wraps(f)
        async def deco(*args, **kwargs):
            request = args[1]
            request.setHeader('Content-Type', 'application/json')
            result = await f(*args, **kwargs)
            return json.dumps(result)
        return deco

    def route(self, url, *args, **kwargs):
        def deco(f):
            f = self.to_json(f)
            self.router.route(url, *args, **kwargs)(f)
        return deco

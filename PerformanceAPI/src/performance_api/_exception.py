# provide a named exception for specializing web request exception
# handlers in the case of no database results, here we're invoking
# `pass` because requires no additional functionality
class NotFound(Exception):
    pass

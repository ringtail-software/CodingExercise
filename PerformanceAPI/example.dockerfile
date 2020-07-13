# base image with full access to build tools
FROM python:3
RUN python -m venv /opt/venv-python

# Copying the source directory means we build the container with the
# latest changes, but for development you would likely instead want to
# sync a directory to reduce frequent building
COPY . /code
RUN /opt/venv-python/bin/pip install /code

# "run" layer without build tools, approximately 1/5th the size of the first layer
FROM python:3-slim
COPY --from=0 /opt/venv-python /opt/venv-python

# the following are for example purposes, the application container
# would not normally persist any data
COPY schema.sql /data/schema.sql
COPY sample-data.sql /data/sample-data.sql
RUN apt update && apt install sqlite3
RUN cat /data/schema.sql /data/sample-data.sql | sqlite3 /data/test.db

ENTRYPOINT ["/opt/venv-python/bin/twist", "performance-api", "-d", "/data/test.db"]

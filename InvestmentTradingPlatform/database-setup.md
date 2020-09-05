# Setting up the database

`MySQL` was chosen as the data store for the **Investment Trading Platform**. I chose to install `MySQL` in a `Docker` container because of it's isolation and ease of deployment. This document assumes the reader has a working installation of `Docker Desktop` (or equivalent) running on their machine. The  document will describe in detail the following steps to installing `MySQL` and setting up the database.

* Install a `MySQL` instance in a `Docker` container.
* Create the database on the `MySQL` instance container.
* Create a user specifically for application access and set their permissions accordingly.

## Step 1 - Install `MySQL` instance in a Docker container

Run the following command from the console:

```bash
docker run --name mysql-code-ex --env MYSQL_ROOT_PASSWORD=6u4o22v2iT --detach --publish 127.0.0.1:3306:3306/tcp --publish 127.0.0.1:33060:33060/tcp mysql:8.0.21
```

#### Notes:

For this exercise I used the `--env` command line option with `MYSQL_ROOT_PASSWORD=<password>`.  In a production scenario we would not store sensitive information in environment variables and would use a different mechanism such as Docker Secrets

The two `--publish` options are required so our application can communicate with the database



## Running commands on the `MySQL` container

In order to create the database we need to execute commands against our `MySQL` server instance. We can do this with the `MySQL command line client`. There are multiple ways to perform this but I will do this by spinning up another docker container that is running the client and connecting it to our `MySQL` server instance.

Run the following command from the console:

```bash
docker run --interactive --tty --network bridge --rm mysql mysql -h"172.17.0.2" -P"3306" -uroot -p
```

#### Notes:

The IP address `172.17.0.2` is the address of the `MySQL` server container and it can be found by running the `docker inspect <container-id>` command.

Everything after `--rm mysql` is the command you want to run so all the optiona `-h`, `-P`, `-u` and `-p` are command line switches to `mysql` **NOT** `docker`

The `-p` option is for the `mysql` command to prompt you for the password of the user given with the `-u` option. Enter `6u4o22v2iT` from the previous step (or if you changed it you will need to enter that value).



## Step 2 - Create the database

Run the following command from the `MySQL command line client`:

```mysql
create database db_investment_trading_platform;
```

#### Notes:

`db_investment_trading_platform` is the name of the database and is used in the application configuration properties (see [configuration](src/main/resources/application.yml).). If you change the name of the database then you must update the configuration.

## Step 3 - Create application user and set permissions

Run the followings command from the `MySQL command line client`:

```mysql
create user 'springuser'@'%' identified by 'RNR9CnuN2g';
grant all on db_investment_trading_platform.* to 'springuser'@'%';
```

#### Notes:

Note that the `springuser` is granted all permissions. In a production environment the permissions would be more restrictive and/or there would be per user permissions (Not a single user accessing the database; depending on design considerations.)

The username and password are used in the application configuration properties (see [configuration](src/main/resources/application.yml).). If you change them then you must update the configuration.

## 
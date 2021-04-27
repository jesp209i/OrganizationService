# Persistence
start database locally by navigating to docker-db and run `docker-compose up`

# Configuration
You need to set different enviroment variables in different projects.

For database connection look into `docker-compose.yml`.

For all project you must set the following, unless stated otherwise

## OrganizationService.WebApi
- DATABASE_CONNECTIONSTRING

## OrganizationService.Worker
- DATABASE_CONNECTIONSTRING
- SERVICEBUS_CONNECTIONSTRING

## ExternalPortal.Api
- SERVICEBUS_CONNECTIONSTRING
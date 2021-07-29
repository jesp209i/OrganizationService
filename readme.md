
# Prerequisites
## Run Database Server
start database by navigating to docker-db and run `docker-compose up`, this starts a MS SQL Server on port 1433 on your computer.

If you already have something running on that port, you could maybe shut it down or change the port in the `docker-compose.yml` file.

## Azure Servicebus
You need a connectionstring for Azure Servicebus.

You can create a bus on the website `portal.azure.com`, but you'll need access to Azure.

# Configuration
You need to set different enviroment variables in different projects.

For database connection look into `docker-compose.yml`.

For all project you must set the following, unless stated otherwise

## OrganizationService.WebApi
- DATABASE_CONNECTIONSTRING
	- connect to server running in docker

## OrganizationService.Worker
- DATABASE_CONNECTIONSTRING
	- connect to server running in docker
- SERVICEBUS_CONNECTIONSTRING
	- connect to servicebus in azure

## ExternalPortal.Api
- SERVICEBUS_CONNECTIONSTRING
	- connect to servicebus in azure 


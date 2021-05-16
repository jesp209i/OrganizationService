namespace OrganizationService.Worker
{
    public static class Constants
    {
        public static class ServiceBus
        {
            public static string InputQueue => "Servicebus_Organization_input".ToLower();
            public static string ErrorQueue => "Servicebus_Organization_Error".ToLower();
        }
        public static class EnvironmentVariables
        {
            public const string ServiceBusConnectionStringEnvironmentVariableName = "SERVICEBUS_CONNECTIONSTRING";
            public const string DatabaseConnectionStringEnvironmentVariableName = "DATABASE_CONNECTIONSTRING";
        }
        public static class Routes
        {
            public const string HealthCheckPath = "/healthcheck";
        }
    }
}

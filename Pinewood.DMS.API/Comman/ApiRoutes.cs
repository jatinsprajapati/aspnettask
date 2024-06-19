namespace Pinewood.DMS.API.Comman
{
    public class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root;//+ "/" + Version;
        public static class Customer
        {
            public const string CreateCustomer = Base + "/createCustomer";
            public const string UpdateCustomer = Base + "/updateCustomer";
            public const string GetCustomerList = Base + "/getCustomerList";
            public const string DeleteCustomer = Base + "/deleteCustomer";
            public const string GetCustomerById = Base + "/getCustomerById";
        }
    }
}

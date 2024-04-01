namespace Grocery.Api.Constants
{
    public static class DatabaseConstants
    {
        public const string ConnectionStringKey = "Grocery";
        public static class Roles
        {
            public static class Admin
            {
                public const int Id = 1;
                public const string Name = "Admin";
            }
            public static class Customer
            {
                public const int Id = 2;
                public const string Name = "Customer";
            }
        }
    }
}

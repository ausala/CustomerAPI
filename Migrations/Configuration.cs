namespace CustomerAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CustomerAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomerAPI.Models.CustomerAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CustomerAPI.Models.CustomerAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Representatives.AddOrUpdate(x => x.Id,
               new Representatives() { Id = 1, Name = "Vilnius Manager", City="Vilnius" },
               new Representatives() { Id = 2, Name = "Kaunas Manager", City = "Kaunas" },
               new Representatives() { Id = 3, Name = "Ryga User", City = "Ryga" }
               );

            context.Customers.AddOrUpdate(x => x.Id,
                new Customers()
                {
                    Id = 1,
                    FirstName = "Petras",
                    LastName = "Petraitis",
                    sex = "Man"
                    ,
                    RepresentatId = 3
                },
                new Customers()
                {
                    Id = 2,
                    FirstName = "Testas",
                    LastName = "Testauskas",
                    sex = "Man"
                    ,
                    RepresentatId = 2
                },
                new Customers()
                {
                    Id = 3,
                    FirstName = "Elza",
                    LastName = "E",
                    sex = "Woman"
                    ,
                    RepresentatId = 1
                },
                new Customers()
                {
                    Id = 4,
                    FirstName = "Anna",
                    LastName = "A",
                    sex = "Woman"
                    ,
                    RepresentatId = 1
                }
                );
        }
    }
}

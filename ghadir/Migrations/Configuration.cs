namespace ghadir.Migrations
{
    using ghadir.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ghadir.Models.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ghadir.Models.MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Products.Any())
            {
                context.Products.Add(new Product()
                {
                    ProductTitle = "دستگاه عبور و مرور یک",
                    Price = 1000,
                    ImageName = "1.jpg"
                });

                context.Products.Add(new Product()
                {
                    ProductTitle = "دستگاه عبور و مرور دو",
                    Price = 2400,
                    ImageName = "2.jpg"
                });

                context.Products.Add(new Product()
                {
                    ProductTitle = "دستگاه عبور و مرور سه",
                    Price = 64500,
                    ImageName = "3.jpg"
                });

                context.Products.Add(new Product()
                {
                    ProductTitle = "دستگاه عبور و مرور چهار",
                    Price = 12000,
                    ImageName = "4.jpg"
                });

                context.Products.Add(new Product()
                {
                    ProductTitle = "دستگاه عبور و مرور پنج",
                    Price = 87000,
                    ImageName = "5.jpg"
                });

                context.SaveChanges();
            }
            //if (!context.Admins.Any())
            //{
            //    context.Admins.Add(new Admin()
            //    {
            //        UserName = "mohammadst@yahoo.com",
            //        Password = 123456789
            //    });

            //    context.Admins.Add(new Admin()
            //    {
            //        UserName = "alist@yahoo.com",
            //        Password = 123456789
            //    });

            //    context.SaveChanges();
            //}
            if (!context.Users.Any())
            {
                context.Roles.AddOrUpdate(r => r.RoleId,
                    new Role() { RoleId = 1, RoleInSystem = "Admin", RoleName = "ادمین", UserId=1 },
                    new Role() { RoleId = 2, RoleInSystem = "user", RoleName = "کاربر", UserId=2 }
                );

                context.Users.AddOrUpdate(u => u.UserId,
                    new User() { UserMail = "admin@mst.ir", FirstName = "Mohammad", LastName = "Sayartehrani", RoleId = 1, PhoneNumber = "09120897913", Password = "Mst123" },
                    new User() { UserMail = "user@mst.ir", FirstName = "Mohammad", LastName = "Sayartehrani", RoleId = 2, PhoneNumber = "09120897913", Password = "Mst123" }
                    );
                context.SaveChanges();
            }
    }
    }
}

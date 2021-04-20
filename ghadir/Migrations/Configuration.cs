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
            {
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
                if (!context.Admins.Any())
                {
                    context.Admins.Add(new Admin()
                    {
                        UserName = "mohammadst@yahoo.com",
                        Password = 123456789
                    });

                    context.Admins.Add(new Admin()
                    {
                        UserName = "alist@yahoo.com",
                        Password = 123456789
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}

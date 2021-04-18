using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ghadir.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
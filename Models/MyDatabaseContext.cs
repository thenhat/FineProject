using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoneyProject.Models
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext() : base("MyConnectionString")
        {

        }
        public DbSet<Money> Moneys { get; set; }

        public System.Data.Entity.DbSet<MoneyProject.Models.Method> Methods { get; set; }
    }
}
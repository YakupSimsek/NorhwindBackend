using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntitiyFramework.Contexs
{
    public class NorntwindContext:DbContext  
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server =((localdb)\MSSQLLocalDB;Datebase=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> products { get; set; }
    }


}

using case1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace case1.Data
{
    internal class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions options) : base(options) { }
        
        public DbSet<Users> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=COM173-LAB3\\SQLEXPRESS;Initial Catalog=User_Management;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}

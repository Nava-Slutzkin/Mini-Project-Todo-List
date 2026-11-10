using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class AppDB : DbContext
    {
        public AppDB(DbContextOptions<AppDB> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}

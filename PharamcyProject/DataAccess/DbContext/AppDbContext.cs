using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContext
{
    class AppDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Pharamcy> Pharamcies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-U9FGG6E\\MSSQLSERVER01;Database=PharamcyConsole;Trusted_Connection=true;");
        }
    }
}

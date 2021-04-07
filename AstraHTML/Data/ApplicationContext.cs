using AstraHTML.Models;
using Microsoft.EntityFrameworkCore;

namespace AstraHTML.Data
{
    class ApplicationContext : DbContext
    {
        //Указываем, что классы являются моделями таблиц из БД
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AstraHTMLDBlocal2;Trusted_Connection=True;");
        }

    }
}

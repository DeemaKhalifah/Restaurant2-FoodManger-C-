using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;


namespace EntityFramwork
{
    public class AppDbContext : DbContext

    {
        public DbSet<Food> foods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connection = new SqlConnection(config.GetSection("Constr").Value);
            optionsBuilder.UseSqlServer(connection);

        }

    }
}

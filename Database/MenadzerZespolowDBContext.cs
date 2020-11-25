using Menadzer_Zespołów.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Configuration;
using System.Text;

namespace Menadzer_Zespołów.Database
{
    public class MenadzerZespolowDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public virtual DbSet<EventModel> Events { get; set; }
    }
}

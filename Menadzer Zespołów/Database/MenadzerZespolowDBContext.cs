using Menadzer_Zespołów.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Menadzer_Zespołów.Database
{
    public class MenadzerZespolowDBContext : DbContext
    {
        public MenadzerZespolowDBContext() : base("name=DefaultConnection")
        {

        }

        public virtual DbSet<EventModel> Events { get; set; }
    }
}

using Menadzer_Zespołów.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Menadzer_Zespołów.Database.Repositiories
{
    public class EventRepository
    {
        public async Task AddEvent(string name, string type, DateTime date)
        {
            using (var db = new MenadzerZespolowDBContext())
            {
                db.Events.Add(new EventModel
                {
                    Name = name,
                    Type = type,
                    Date = date
                }) ;
                await db.SaveChangesAsync();
            }
        }

        // Async select task don't work correctly. Insert to database is ok, but select query takes a long time to return a value. Come back to non async solution. 
        public List<EventModel> GetAll()
        {
            using (var db = new MenadzerZespolowDBContext())
            {
                var result = (from b in db.Events
                                    select b).ToList();
                return result;
            }
        }
    }
}

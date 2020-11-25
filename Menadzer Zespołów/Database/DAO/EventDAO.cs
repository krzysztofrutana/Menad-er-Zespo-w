using Menadzer_Zespołów.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Menadzer_Zespołów.Database.DAO
{
    class EventDAO
    {
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

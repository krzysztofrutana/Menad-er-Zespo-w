using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Menadzer_Zespołów.Database.Entities
{
    [Table("Events")]
    public class EventModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime? Date { get; set; }

    }
}

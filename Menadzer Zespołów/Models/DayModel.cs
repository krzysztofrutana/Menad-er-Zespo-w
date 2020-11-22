using System;
using System.Collections.Generic;
using System.Text;

namespace Menadzer_Zespołów.Models
{
    public class DayModel
    {
        private DateTime _Date;

        public DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
            }
        }

        public int DayOfMonth
        {
            get
            {
                return Date.Day;
            }
        }

        public String NameOfDay
        {
            get
            {
                var culture = new System.Globalization.CultureInfo("pl-PL");
                string dayName = culture.DateTimeFormat.GetDayName(Date.DayOfWeek);

                return char.ToUpper(dayName[0]) + dayName.Substring(1);
            }
        }

        public DayModel(DateTime date)
        {
            this.Date = date;
        }
    }
}

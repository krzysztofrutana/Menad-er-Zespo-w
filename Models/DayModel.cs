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

        public int GetYear
        {
            get
            {
                return Date.Year;
            }
        }

        public String NameOfMonth
        {
            get
            {
                var culture = new System.Globalization.CultureInfo("pl-PL");
                string dayName = culture.DateTimeFormat.GetMonthName(Date.Month);

                return char.ToUpper(dayName[0]) + dayName.Substring(1);
            }
        }

        public string Type { get; set; }


        public bool ItsDayInCurrentMonth { get; set; }

        public DayModel(DateTime date, string type = null)
        {
            this.Date = date;
            this.Type = type; 
        }
    }
}

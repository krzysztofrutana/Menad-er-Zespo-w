using Menadzer_Zespołów.Models;
using Menadzer_Zespołów.Utils;
using Menadzer_Zespołów.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Input;

namespace Menadzer_Zespołów.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {
        private DayModel[] _calendarModel;

        public DayModel[] calendarModel
        {
            get { return _calendarModel; }
            set { _calendarModel = value;
                OnPropertyChanged("calendarModel");
            }
        }

        private List<DayModel> _weekNames;

        public List<DayModel> weekNames
        {
            get { return _weekNames; }
            set
            {
                _weekNames = value;
                OnPropertyChanged("calendarModel");
            }
        }
        // public WeekNamesModel weekNames ;
        //  public List<String> daysOfWeekNames;

        public CalendarViewModel()
        {
            this.calendarModel = CalendarMonthModelBuild.Create(DateTime.Now);
            this.weekNames = CalendarMonthModelBuild.GenerateWeekNameList(calendarModel);

        }
    }
}

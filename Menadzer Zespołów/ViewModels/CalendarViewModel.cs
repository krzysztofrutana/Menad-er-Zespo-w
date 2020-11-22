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

        private DateTime _CurrentUsedDateTimeForMakeModel;

        public DateTime CurrentUsedDateTimeForMakeModel
        {
            get { return _CurrentUsedDateTimeForMakeModel; }
            set
            {
                _CurrentUsedDateTimeForMakeModel = value;
                OnPropertyChanged(nameof(CurrentUsedDateTimeForMakeModel));
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

        private String _NameOfCurrentMonth;
        public String NameOfCurrentMonth
        {
            get
            {
                return _NameOfCurrentMonth;
            }
            set
            {
                _NameOfCurrentMonth = value;
                OnPropertyChanged(nameof(NameOfCurrentMonth));
            }
        }

        private int _CurrentYear;
        public int CurrentYear
        { 
            get
            {
                return _CurrentYear;
            }
            set
            {
                _CurrentYear = value;
                OnPropertyChanged(nameof(CurrentYear));
            }
        }

        public CalendarViewModel()
        {
            SettingsCalendarView(DateTime.Now);
        }

        private void SettingsCalendarView(DateTime date)
        {
            CurrentUsedDateTimeForMakeModel = date;
            calendarModel = CalendarMonthModelBuild.Create(date);
            weekNames = CalendarMonthModelBuild.GenerateWeekNameList(calendarModel);
            SetPropertyForCalendarHeader();
        }

        private void SetPropertyForCalendarHeader()
        {
            for (int i = 0; i < calendarModel.Length; i++)
            {
                if (calendarModel[i].DayOfMonth == 1)
                {
                    NameOfCurrentMonth = calendarModel[i].NameOfMonth;
                    CurrentYear = calendarModel[i].GetYear;
                    break;
                }
            }
        }



        private ICommand _ChangeMonthToPrevious;

        public ICommand ChangeMonthToPrevious
        {
            get
            {
                if (_ChangeMonthToPrevious == null)
                {
                    _ChangeMonthToPrevious = new RelayCommand(parametr =>
                    {
                        CurrentUsedDateTimeForMakeModel = CurrentUsedDateTimeForMakeModel.AddMonths(-1);
                        calendarModel = CalendarMonthModelBuild.Create(CurrentUsedDateTimeForMakeModel);
                        SetPropertyForCalendarHeader();
                    }, null);
                }
                return _ChangeMonthToPrevious;
            }
        }

        private ICommand _ChangeMonthToNext;

        public ICommand ChangeMonthToNext
        {
            get
            {
                if (_ChangeMonthToNext == null)
                {
                    _ChangeMonthToNext = new RelayCommand(parametr =>
                    {
                        CurrentUsedDateTimeForMakeModel = CurrentUsedDateTimeForMakeModel.AddMonths(1);
                        calendarModel = CalendarMonthModelBuild.Create(CurrentUsedDateTimeForMakeModel);
                        SetPropertyForCalendarHeader();
                    }, null);
                }
                return _ChangeMonthToNext;
            }
        }
    }
}

using Menadzer_Zespołów.Models;
using Menadzer_Zespołów.Utils;
using Menadzer_Zespołów.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Menadzer_Zespołów.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {
        private DayModel[] _CalendarModel;

        public DayModel[] CalendarModel
        {
            get { return _CalendarModel; }
            set
            {
                _CalendarModel = value;
                if (WeekNames == null)
                {
                    WeekNames = CalendarMonthModelBuild.GenerateWeekNameList(value);
                }
                SetPropertyForCalendarHeader();
                ShowLoadingScreen = false;
                OnPropertyChanged("CalendarModel");
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

        private List<DayModel> _WeekNames;

        public List<DayModel> WeekNames
        {
            get { return _WeekNames; }
            set
            {
                _WeekNames = value;
                ShowYearButton = true;
                OnPropertyChanged(nameof(WeekNames));
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

        private Boolean _ShowLoadingScreen;
        public Boolean ShowLoadingScreen
        {
            get { return _ShowLoadingScreen; }
            set
            {
                _ShowLoadingScreen = value;
                OnPropertyChanged(nameof(ShowLoadingScreen));
            }
        }

        private Boolean _ShowYearButton;
        public Boolean ShowYearButton
        {
            get { return _ShowYearButton; }
            set
            {
                _ShowYearButton = value;
                OnPropertyChanged(nameof(ShowYearButton));
            }
        }

        public CalendarViewModel()
        {
            if(CalendarModel == null)
            {
                ShowYearButton = false;
            }
            SettingsCalendarView(DateTime.Now);
        }

        private void SettingsCalendarView(DateTime date)
        {
            CurrentUsedDateTimeForMakeModel = date;
            CreateCalendarModel(date);

        }


        private void SetPropertyForCalendarHeader()
        {

            NameOfCurrentMonth = CalendarModel[15].NameOfMonth;
            CurrentYear = CalendarModel[21].GetYear;

        }

        private void CreateCalendarModel(DateTime date)
        {
            ShowLoadingScreen = true;
            Task taskA = new Task(() => CalendarModel = CalendarMonthModelBuild.Create(date));
            taskA.Start();
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
                        CreateCalendarModel(CurrentUsedDateTimeForMakeModel);
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
                        CreateCalendarModel(CurrentUsedDateTimeForMakeModel);
                        SetPropertyForCalendarHeader();
                    }, null);
                }
                return _ChangeMonthToNext;
            }
        }
    }
}

using Menadzer_Zespołów.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Menadzer_Zespołów.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private CalendarView calendarView;
        private EventListView eventListView;
        private AddNewEventListView addNewEventListView;

        private Boolean _showBarInCalendarMenuButton;

        public Boolean showBarInCalendarMenuButton
        {
            get { return _showBarInCalendarMenuButton; }
            set
            {
                _showBarInCalendarMenuButton = value;
                OnPropertyChanged(nameof(showBarInCalendarMenuButton));
            }
        }

        private Boolean _showBarInEventListMenuButton;

        public Boolean showBarInEventListMenuButton
        {
            get { return _showBarInEventListMenuButton; }
            set
            {
                _showBarInEventListMenuButton = value;
                OnPropertyChanged(nameof(showBarInEventListMenuButton));
            }
        }

        private Boolean _showBarInAddNewEventMenuButton;

        public Boolean showBarInAddNewEventMenuButton
        {
            get { return _showBarInAddNewEventMenuButton; }
            set
            {
                _showBarInAddNewEventMenuButton = value;
                OnPropertyChanged(nameof(showBarInAddNewEventMenuButton));
            }
        }



        public MainWindowViewModel()
        {
            CurrentWindowState = WindowState.Normal;
            calendarView = new CalendarView();
            eventListView = new EventListView();
            addNewEventListView = new AddNewEventListView();
            showBarInCalendarMenuButton = false;
            showBarInEventListMenuButton = false;
            showBarInAddNewEventMenuButton = false;
        }


        object selectedView;
        public object SelectedView
        {
            get { return selectedView; }
            private set
            {
                selectedView = value;
                OnPropertyChanged("SelectedView");
            }
        }


        private ICommand _showCalendarView;

        public ICommand showCalendarView
        {
            get
            {
                if (_showCalendarView == null)
                {
                    _showCalendarView = new RelayCommand(parametr =>
                    {
                        showBarInCalendarMenuButton = true;
                        showBarInEventListMenuButton = false;
                        showBarInAddNewEventMenuButton = false;
                        SelectedView = calendarView;
                    }, null);
                }
                return _showCalendarView;
            }
        }

        private ICommand _showEventListView;

        public ICommand showEventListView
        {
            get
            {
                if (_showEventListView == null)
                {
                    _showEventListView = new RelayCommand(parametr =>
                    {
                        showBarInCalendarMenuButton = false;
                        showBarInEventListMenuButton = true;
                        showBarInAddNewEventMenuButton = false;
                        SelectedView = eventListView;
                    }, null);
                }
                return _showEventListView;
            }
        }

        private ICommand _showAddNewEventView;

        public ICommand showAddNewEventView
        {
            get
            {
                if (_showAddNewEventView == null)
                {
                    _showAddNewEventView = new RelayCommand(parametr =>
                    {
                        showBarInCalendarMenuButton = false;
                        showBarInEventListMenuButton = false;
                        showBarInAddNewEventMenuButton = true;
                        SelectedView = addNewEventListView;
                    }, null);
                }
                return _showAddNewEventView;
            }
        }


        private WindowState _currentWindowState;
        public WindowState CurrentWindowState
        {
            get
            {
                return _currentWindowState;
            }
            set
            {
                _currentWindowState = value;
                OnPropertyChanged("CurrentWindowState");
            }
        }

        private ICommand _closeWindow;

        public ICommand closeWindow
        {
            get
            {
                if (_closeWindow == null)
                {
                    _closeWindow = new RelayCommand(parametr => 
                    {
                        Application.Current.Shutdown();
                    }, null);
                }
                return _closeWindow;
            }
        }

        private ICommand _minimizeWindow;

        public ICommand minimizeWindow
        {
            get
            {
                if (_minimizeWindow == null)
                {
                    _minimizeWindow = new RelayCommand(
                        parametr =>
                        {
                            CurrentWindowState = WindowState.Minimized;
                        }
                        , null);
                }
                return _minimizeWindow;
            }
        }


        private ICommand _maximizeWindow;

        public ICommand maximizeWindow
        {
            get
            {
                if (_maximizeWindow == null)
                {
                    _maximizeWindow = new RelayCommand(
                        parametr =>
                        {
                            if (CurrentWindowState == WindowState.Maximized)
                            {
                                CurrentWindowState = WindowState.Normal;
                            }
                            else
                            {
                                CurrentWindowState = WindowState.Maximized;
                            }
                        }, 
                        null);
                }
                return _maximizeWindow;
            }
        }

        private ICommand _resetWindowSize;

        public ICommand resetWindowSize
        {
            get
            {
                if (_resetWindowSize == null)
                {
                    _resetWindowSize = new RelayCommand(
                        parametr => 
                        {
                            CurrentWindowState = WindowState.Normal;
                        },
                        null);
                }
                return _resetWindowSize;
            }
        }
        
    }
}

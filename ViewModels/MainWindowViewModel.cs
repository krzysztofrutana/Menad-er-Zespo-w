using Google.Apis.Drive.v3;
using Menadzer_Zespołów.Utils;
using Menadzer_Zespołów.Views;
using System;
using System.Collections.Generic;
using System.IO;
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
        
        private GoogleDriveHelper googleDriveHelper;
        private string tokenPath = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal);
        
        private DriveService _GoogleDriveService;
        public DriveService GoogleDriveService
        {
            get { return _GoogleDriveService; }
            set
            {
                _GoogleDriveService = value;
                OnPropertyChanged(nameof(GoogleDriveService));
            }
        }

        private string _LoggedInAccount;
        public string LoggedInAccount
        {
            get { return _LoggedInAccount; }
            set
            {
                _LoggedInAccount = value;
                if (value != "")
                {
                    ShowLoggedInInformation = true;
                    ShowLogInButton = false;
                }
                else { ShowLoggedInInformation = false; }

                OnPropertyChanged(nameof(LoggedInAccount));
            }
        }

        private Boolean _ShowLoggedInInformation;

        public Boolean ShowLoggedInInformation
        {
            get { return _ShowLoggedInInformation; }
            set
            {
                _ShowLoggedInInformation = value;
                OnPropertyChanged(nameof(ShowLoggedInInformation));
            }
        }

        private Boolean _ShowLogInButton;

        public Boolean ShowLogInButton
        {
            get { return _ShowLogInButton; }
            set
            {
                _ShowLogInButton = value;
                OnPropertyChanged(nameof(ShowLogInButton));
            }
        }

        private Boolean _ShowBarInCalendarMenuButton;

        public Boolean ShowBarInCalendarMenuButton
        {
            get { return _ShowBarInCalendarMenuButton; }
            set
            {
                _ShowBarInCalendarMenuButton = value;
                OnPropertyChanged(nameof(ShowBarInCalendarMenuButton));
            }
        }

        private Boolean _ShowBarInEventListMenuButton;

        public Boolean ShowBarInEventListMenuButton
        {
            get { return _ShowBarInEventListMenuButton; }
            set
            {
                _ShowBarInEventListMenuButton = value;
                OnPropertyChanged(nameof(ShowBarInEventListMenuButton));
            }
        }

        private Boolean _ShowBarInAddNewEventMenuButton;

        public Boolean ShowBarInAddNewEventMenuButton
        {
            get { return _ShowBarInAddNewEventMenuButton; }
            set
            {
                _ShowBarInAddNewEventMenuButton = value;
                OnPropertyChanged(nameof(ShowBarInAddNewEventMenuButton));
            }
        }



        public MainWindowViewModel()
        {
            CurrentWindowState = WindowState.Normal;

            ShowBarInCalendarMenuButton = false;
            ShowBarInEventListMenuButton = false;
            ShowBarInAddNewEventMenuButton = false;
            ShowLogInButton = true;
            googleDriveHelper = new GoogleDriveHelper();
            tokenPath = Path.Combine(tokenPath, ".credentials\\menadzer_zespolow_token.json");
            if (Directory.Exists(tokenPath))
            {
                GoogleDriveService =  googleDriveHelper.GetGoogleDriveService();
                LoggedInAccount = "Zalogowano";
            }
        }


        object _SelectedView;
        public object SelectedView
        {
            get { return _SelectedView; }
            private set
            {
                _SelectedView = value;
                OnPropertyChanged("SelectedView");
            }
        }


        private ICommand _ShowCalendarView;

        public ICommand ShowCalendarView
        {
            get
            {
                if (_ShowCalendarView == null)
                {
                    _ShowCalendarView = new RelayCommand(parametr =>
                    {
                        ShowBarInCalendarMenuButton = true;
                        ShowBarInEventListMenuButton = false;
                        ShowBarInAddNewEventMenuButton = false;
                        calendarView = new CalendarView();
                        SelectedView = calendarView;
                    }, null);
                }
                return _ShowCalendarView;
            }
        }

        private ICommand _ShowEventListView;

        public ICommand ShowEventListView
        {
            get
            {
                if (_ShowEventListView == null)
                {
                    _ShowEventListView = new RelayCommand(parametr =>
                    {
                        ShowBarInCalendarMenuButton = false;
                        ShowBarInEventListMenuButton = true;
                        ShowBarInAddNewEventMenuButton = false;
                        eventListView = new EventListView();
                        SelectedView = eventListView;
                    }, null);
                }
                return _ShowEventListView;
            }
        }

        private ICommand _ShowAddNewEventView;

        public ICommand ShowAddNewEventView
        {
            get
            {
                if (_ShowAddNewEventView == null)
                {
                    _ShowAddNewEventView = new RelayCommand(parametr =>
                    {
                        ShowBarInCalendarMenuButton = false;
                        ShowBarInEventListMenuButton = false;
                        ShowBarInAddNewEventMenuButton = true;
                        addNewEventListView = new AddNewEventListView();
                        SelectedView = addNewEventListView;
                    }, null);
                }
                return _ShowAddNewEventView;
            }
        }


        private WindowState _CurrentWindowState;
        public WindowState CurrentWindowState
        {
            get
            {
                return _CurrentWindowState;
            }
            set
            {
                _CurrentWindowState = value;
                OnPropertyChanged("CurrentWindowState");
            }
        }

        private ICommand _CloseWindow;

        public ICommand CloseWindow
        {
            get
            {
                if (_CloseWindow == null)
                {
                    _CloseWindow = new RelayCommand(parametr =>
                    {
                        Application.Current.Shutdown();
                    }, null);
                }
                return _CloseWindow;
            }
        }

        private ICommand _MinimizeWindow;

        public ICommand MinimizeWindow
        {
            get
            {
                if (_MinimizeWindow == null)
                {
                    _MinimizeWindow = new RelayCommand(
                        parametr =>
                        {
                            CurrentWindowState = WindowState.Minimized;
                        }
                        , null);
                }
                return _MinimizeWindow;
            }
        }


        private ICommand _MaximizeWindow;

        public ICommand MaximizeWindow
        {
            get
            {
                if (_MaximizeWindow == null)
                {
                    _MaximizeWindow = new RelayCommand(
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
                return _MaximizeWindow;
            }
        }

        private ICommand _ResetWindowSize;

        public ICommand ResetWindowSize
        {
            get
            {
                if (_ResetWindowSize == null)
                {
                    _ResetWindowSize = new RelayCommand(
                        parametr =>
                        {
                            CurrentWindowState = WindowState.Normal;
                        },
                        null);
                }
                return _ResetWindowSize;
            }
        }

        private ICommand _LogInToGoogleDrive;

        public ICommand LogInToGoogleDrive
        {
            get
            {
                if (_LogInToGoogleDrive == null)
                {
                    _LogInToGoogleDrive = new RelayCommand(
                        parametr =>
                        {
                            GoogleDriveService =  googleDriveHelper.GetGoogleDriveService();
                            LoggedInAccount = "Zalogowano";
                        },
                        null);
                }
                return _LogInToGoogleDrive;
            }
        }

    }
}

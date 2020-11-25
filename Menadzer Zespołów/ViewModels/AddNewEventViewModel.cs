using Menadzer_Zespołów.Database.Repositiories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Menadzer_Zespołów.ViewModels
{
    public class AddNewEventViewModel : ViewModelBase
    {

        public AddNewEventViewModel()
        {
            eventRepository = new EventRepository();
        }

        private EventRepository eventRepository;

        private string _EventName;

        public string EvenName
        {
            get
            {
                return _EventName;
            }
            set
            {
                _EventName = value;
                OnPropertyChanged(nameof(EvenName));
            }
        }

        private string _Type;

        public string Type
        {
            get { return _Type; }
            set { _Type = value;
                OnPropertyChanged(nameof(Type)); }
        }

        public string EventDateStr { get; set; }

        private DateTime _EventDate;
        
        public DateTime EventDate
        {
            get { return _EventDate; }
            set { _EventDate = value;
                OnPropertyChanged(nameof(EvenName));
            }
        }


        private ICommand _AddEventToDatabase;

        public ICommand AddEventToDatabase
        {
            get
            {
                if(_AddEventToDatabase == null)
                {
                    _AddEventToDatabase = new RelayCommand(async parametr =>
                    {
                        EventDate = DateTime.Parse(EventDateStr);
                        await eventRepository.AddEvent(EvenName, Type, EventDate);
                        OnPropertyChanged("ListOfEvents");
                    },canExecute =>
                    {
                        if(EvenName != null && Type != null && EventDateStr != null)
                        {
                            if(EvenName != "" && Type != "" && EventDateStr != "")
                            {
                                return true;
                            }
                            else { return false; }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    );
                }
                return _AddEventToDatabase;
            }
        }
    }
}

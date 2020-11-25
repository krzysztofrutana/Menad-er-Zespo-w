using Menadzer_Zespołów.Database.Entities;
using Menadzer_Zespołów.Database.Repositiories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Menadzer_Zespołów.ViewModels
{
    public class EventListViewModel : ViewModelBase
    {

        private Boolean _ShowLoadingScreen;

        public Boolean ShowLoadingScreen
        {
            get { return _ShowLoadingScreen; }
            set { _ShowLoadingScreen = value;
                OnPropertyChanged(nameof(ShowLoadingScreen));
            }
        }

        private List<EventModel> _EventsList;

        public List<EventModel> EventsList
        {
            get { return _EventsList; }
            set
            {
                _EventsList = value;
                ShowLoadingScreen = false;
                OnPropertyChanged(nameof(EventsList));
            }
        }

        private EventRepository eventRepository; 

        public EventListViewModel()
        {
            ShowLoadingScreen = true;
            eventRepository = new EventRepository();

            LoadData();
        }

        private void LoadData()
        {
            Task taskA = new Task(() => EventsList = eventRepository.GetAll());
            taskA.Start();
        }

    }
}

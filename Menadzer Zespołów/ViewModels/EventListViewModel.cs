using Menadzer_Zespołów.Database.Entities;
using Menadzer_Zespołów.Database.Repositiories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Menadzer_Zespołów.ViewModels
{
    public class EventListViewModel : ViewModelBase
    {

        private List<EventModel> _EventsList;

        public List<EventModel> EventsList
        {
            get { return _EventsList; }
            set
            {
                _EventsList = value;
                OnPropertyChanged(nameof(EventsList));
            }
        }
        private EventRepository eventRepository; 

        public EventListViewModel()
        {
            eventRepository = new EventRepository();
            EventsList = eventRepository.GetAll();
        }
    }
}

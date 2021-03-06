﻿using iBalekaAPI.Data.Infastructure;
using iBalekaAPI.Data.Repositories;
using iBalekaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBalekaAPI.Services
{
    public interface IEventService
    {
        Event GetEventByID(int id);
        IEnumerable<EventRoute> GetEventRoutes(int id);
        IEnumerable<Event> GetUserEvents(string userId);
        IEnumerable<Event> GetEvents();
        void AddEvent(Event evnt);

        void UpdateEvent(Event evnt);
        void Delete(Event evnt);
        void DeleteEventRoutes(IEnumerable<EventRoute> evntRoute);
        void SaveEvent();
    }
    public class EventService:IEventService
    {
        private readonly IEventRepository _eventRepo;
        private readonly IUnitOfWork unitOfWork;

        public EventService(IEventRepository _repo,IUnitOfWork _unitOfWork)
        {
            _eventRepo = _repo;
            unitOfWork = _unitOfWork;
        }
        public Event GetEventByID(int id)
        {
            return _eventRepo.GetEventByID(id);
        }
        public IEnumerable<Event> GetUserEvents(string userId)
        {
            return _eventRepo.GetUserEvents(userId);
        }
        public IEnumerable<Event> GetEvents()
        {
            return _eventRepo.GetEvents();
        }
        public IEnumerable<EventRoute> GetEventRoutes(int id)
        {
            return _eventRepo.GetEventRoutes(id);
        }
        public void AddEvent(Event evnt)
        {
            _eventRepo.AddEvent(evnt);
        }
       
        public void UpdateEvent(Event evnt)
        {
            _eventRepo.UpdateEvent(evnt);
        }
        public void Delete(Event evnt)
        {
            _eventRepo.Delete(evnt);
        }
        public void DeleteEventRoutes(IEnumerable<EventRoute> evntRoute)
        {
            _eventRepo.DeleteEventRoutes(evntRoute);
        }

        public void SaveEvent()
        {
            unitOfWork.Commit();
        }
    }
}

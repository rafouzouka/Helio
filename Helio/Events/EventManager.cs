using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Helio.Events
{
    public class EventManager
    {
        private Queue<Event> _eventQueue;
        private Dictionary<Type, List<Action<Event>>> _eventListenerMap;
        
        private static readonly Lazy<EventManager> lazy = new Lazy<EventManager>(() => new EventManager());

        private EventManager()
        {
            _eventQueue = new Queue<Event>();
            _eventListenerMap = new Dictionary<Type, List<Action<Event>>>();
        }

        public static EventManager Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public void AddListener(Action<Event> listener, Type eventType)
        {
            if (!_eventListenerMap.ContainsKey(eventType))
            {
                _eventListenerMap.Add(eventType, new List<Action<Event>>());
            }
           _eventListenerMap[eventType].Add(listener);
        }

        public void RemoveListener(Action<Event> listener, Type eventType)
        {
            _eventListenerMap[eventType].Remove(listener);
        }

        public void TriggerEvent(Event evnt)
        {
            if (_eventListenerMap.ContainsKey(evnt.GetType()) == true) 
            {
                foreach (Action<Event> listener in _eventListenerMap[evnt.GetType()])
                {
                    listener.Invoke(evnt);
                }
            }
        }

        public void QueueEvent(Event evnt)
        {
            _eventQueue.Enqueue(evnt);
        }

        public void Update()
        {
            while (_eventQueue.Count > 0)
            {
                Event evnt = _eventQueue.Dequeue();
                TriggerEvent(evnt);
            }
        }
    }
}

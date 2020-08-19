using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public class EventParams
    {
        static public EventParams Create(string key, object val)
        {
            var param = new EventParams();
            param._map.Add(key, val);
            return param;
        }

        public bool HasParam(string key)
        {
            return _map.ContainsKey(key);
        }

        public int GetInt(string key, int defVal)
        {
            if (_map.ContainsKey(key))
            {
                return (int)_map[key];
            }
            return defVal;
        }
        public void SetInt(string key, int val)
        {
            _map.Add(key, val);
        }

        public string GetString(string key, string defVal)
        {
            if (_map.ContainsKey(key))
            {
                return (string)_map[key];
            }
            return defVal;
        }
        public void SetString(string key, string val)
        {
            _map.Add(key, val);
        }



        Dictionary<string, object> _map = new Dictionary<string, object>();
    }
    
    public class Subject
    {
        public const string EVENT_BROADCAST = "Event.*";

        Dictionary<string, List<ISubscriber>> _subscribers = new Dictionary<string, List<ISubscriber>>();

        void Notify(string eventId, EventParams eventParams)
        {
            if (_subscribers.ContainsKey(eventId))
            {
                foreach (var subscriber in _subscribers[eventId])
                {
                    subscriber.OnNotified(eventId, eventParams);
                }
            }
        }

        void Broadcast(string eventId, EventParams eventParams)
        {
            if (_subscribers.ContainsKey(EVENT_BROADCAST))
            {
                foreach (var subscriber in _subscribers[EVENT_BROADCAST])
                {
                    subscriber.OnNotified(eventId, eventParams);
                }
            }
        }

        protected void NotifyAboutEvent(string eventId, EventParams eventParams)
        {
            Notify(eventId, eventParams);
            Broadcast(eventId, eventParams);
        }

        public void Subscribe(string eventId, ISubscriber subscriber)
        {
            if (eventId == "" || eventId == "*")
            {
                eventId = EVENT_BROADCAST;
            }

            if (!_subscribers.ContainsKey(eventId))
            {
                _subscribers.Add(eventId, new List<ISubscriber>());
            }

            if (!_subscribers[eventId].Contains(subscriber))
            {
                _subscribers[eventId].Add(subscriber);
            }
        }
    }

    public interface ISubscriber
    {
        void OnNotified(string eventId, EventParams eventParams);
    }
}

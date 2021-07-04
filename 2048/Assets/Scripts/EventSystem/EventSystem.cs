using System;
using System.Collections.Generic;

namespace Game2048
{
    public static class EventSystem
    {
        private static IDictionary<Type, object> _eventListeners = new Dictionary<Type, object>();

        public static void AddListener<T>(object listener, Action<T> listenerAction)
        {
            if(_eventListeners.TryGetValue(typeof(T), out var currentEventContainer))
            {
                var container = currentEventContainer as EventContainer<T>;
                container.AddEvent(listener, listenerAction);
            }
            else
            {
                currentEventContainer = new EventContainer<T>(listener, listenerAction);
                _eventListeners.Add(typeof(T), currentEventContainer);
            }
        }

        public static void RemoveListener<T>(object listener)
        {
            if (_eventListeners.TryGetValue(typeof(T), out var currentEventContainer))
            {
                var container = currentEventContainer as EventContainer<T>;
                container.RemoveEvent(listener);
            }
        }

        public static void ExecuteEvent<T>(T eventArg)
        {
            if(_eventListeners.TryGetValue(typeof(T), out var currentEventContainer))
            {
                var container = currentEventContainer as EventContainer<T>;
                container.ExecuteEvent(eventArg);
            }
        }
    }
}
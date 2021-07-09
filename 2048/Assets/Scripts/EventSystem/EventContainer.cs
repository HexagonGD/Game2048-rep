using System;
using System.Collections.Generic;
using System.Linq;

namespace Game2048
{
    public class EventContainer<T>
    {
        private event Action<T> _executeAction;
        private IDictionary<WeakReference, Action<T>> _listeners = new Dictionary<WeakReference, Action<T>>();

        public EventContainer(object listener, Action<T> listenerAction)
        {
            AddEvent(listener, listenerAction);
        }

        public void AddEvent(object listener, Action<T> listenerAction)
        {
            if (!IsContain(listener))
            {
                _listeners[new WeakReference(listener)] = listenerAction;
                _executeAction += listenerAction;
            }
        }

        public void RemoveEvent(object listener)
        {
            if(TryGetListenerAction(listener, out var listenerReference))
            {
                _executeAction -= _listeners[listenerReference];
                _listeners.Remove(listenerReference);
            }
        }

        public void ExecuteEvent(T eventArg)
        {
            _executeAction?.Invoke(eventArg);
        }

        private bool IsContain(object listener)
        {
            return _listeners.Keys.Any(x => x.Target == listener);
        }

        private bool TryGetListenerAction(object listener, out WeakReference listenerReference)
        {
            listenerReference = _listeners.Keys.FirstOrDefault(x => x.Target == listener);
            return listenerReference != null;
        }
    }
}
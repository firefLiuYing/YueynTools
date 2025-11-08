using System;
using System.Collections.Generic;
using Yueyn.Utils;

namespace Yueyn.Base.EventPool
{
    public sealed partial class EventPool<T> where T:BaseEventArgs
    {
        private readonly MultiDictionary<int, EventHandler<T>> _eventHandlers;
        private readonly Queue<Event> _events;
        private readonly EventPoolMode _eventPoolMode;
        private readonly MultiDictionary<object, EventHandler<T>> _cachedNodes;
        private readonly MultiDictionary<object, EventHandler<T>> _tempNodes;
        
        private EventHandler<T> _defaultHandler;

        public EventPool(EventPoolMode mode)
        {
            _eventHandlers = new();
            _events = new();
            _eventPoolMode = mode;
            _defaultHandler = null;
        }

        public void Update(float elapseSeconds, float realElapseSeconds)
        {
            lock (_events)
            {
                while (_events.Count > 0)
                {
                    var eventNode=_events.Dequeue();
                    
                }
            }
        }

        private void HandleEvent(object sender, T e)
        {
            bool noHandlerException = false;
            if (_eventHandlers.TryGetValue(e.Id, out List<EventHandler<T>> handlers))
            {
                
            }
        }
    }
}
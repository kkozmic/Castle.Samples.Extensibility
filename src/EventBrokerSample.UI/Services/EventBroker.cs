using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EventBrokerSample.UI.Services
{
    public class EventBroker : IEventPublisher, IEventRegister
    {
        private readonly IList<object> listeners;

        private readonly SynchronizationContext context;

        public EventBroker(SynchronizationContext context, IList<object> listeners)
        {
            this.context = context;
            this.listeners = listeners;
        }

        public void Publish<T>(T message)
        {
            context.Send(state => listeners
                                      .Select(obj => obj as IListener<T>)
                                      .Where(listener => listener != null)
                                      .Each(listener => listener.Handle(message)), null);
        }

        public void Register(object listener)
        {
            if (listeners.Contains(listener)) return;
            listeners.Add(listener);
        }

        public void Unregister(object listener)
        {
            if (listeners.Contains(listener) == false) return;
            listeners.Remove(listener);
        }
    }
}
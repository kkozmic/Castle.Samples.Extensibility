using System;
using System.Linq;
using Castle.Core;
using EventBrokerSample.UI.Services;

namespace EventBrokerSample.UI.Infrastructure
{
    public static class ComponentModelExtensions
    {
        private static readonly Type LISTENER = typeof(IListener<>);

        public static bool ImplementationIsAListener(this ComponentModel model)
        {
            return model
                .Implementation
                .GetInterfaces()
                .Where(i => i.IsGenericType)
                .Select(i => i.GetGenericTypeDefinition())
                .Any(i => i == LISTENER);
        }
    }
}
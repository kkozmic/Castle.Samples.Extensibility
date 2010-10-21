using System.Collections.Generic;
using System.Threading;
using EventBrokerSample.UI.Services;
using Moq;
using NUnit.Framework;

namespace EventBrokerSample.Tests.Services
{
    public abstract class EventBrokerAsRegisterSpec
    {
        protected List<object> listeners;
        protected Mock<SynchronizationContext> context;

        [SetUp]
        public void Setup()
        {
            listeners = new List<object>();
            context = new Mock<SynchronizationContext>();
        }

        protected IEventRegister CreateSut()
        {
            return new EventBroker(context.Object, listeners);
        }
    }

    [TestFixture]
    public class When_a_listener_is_regsitered_to_the_EventBroker
        : EventBrokerAsRegisterSpec
    {
        [Test]
        public void it_should_be_added_to_the_list_of_listeners()
        {
            var listener = new Mock<IListener<object>>().Object;

            CreateSut().Register(listener);
            Assert.That(listeners.Contains(listener));
        }
    }

    [TestFixture]
    public class When_a_registered_listener_is_regsitered_to_the_EventBroker_again
        : EventBrokerAsRegisterSpec
    {
        [Test]
        public void it_should_not_be_added_to_the_list()
        {
            var listener = new Mock<IListener<object>>().Object;
            listeners.Add(listener);

            CreateSut().Register(listener);
            Assert.That(listeners.Count.Equals(1));
        }
    }

    [TestFixture]
    public class When_a_registered_listener_is_unregsitered_from_the_EventBroker
        : EventBrokerAsRegisterSpec
    {
        [Test]
        public void it_should_be_removed_from_the_list_of_listeners()
        {
            var listener = new Mock<IListener<object>>().Object;
            listeners.Add(listener);

            CreateSut().Unregister(listener);
            Assert.That(listeners.Count.Equals(0));
        }
    }

    [TestFixture]
    public class When_an_unregistered_listener_is_unregsitered_from_the_EventBroker
        : EventBrokerAsRegisterSpec
    {
        [Test]
        public void nothing_should_change()
        {
            listeners.Add(new Mock<IListener<object>>().Object);

            CreateSut().Unregister(new Mock<IListener<object>>().Object);
            Assert.That(listeners.Count.Equals(1));
        }
    }
}
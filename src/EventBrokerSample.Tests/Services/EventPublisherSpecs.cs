using System.Collections.Generic;
using System.Threading;
using EventBrokerSample.UI.Services;
using Moq;
using NUnit.Framework;

namespace EventBrokerSample.Tests.Services
{
    public abstract class EventBrokerAsPublisherSpec
    {
        protected List<object> listeners;
        protected Mock<SynchronizationContext> context;

        [SetUp]
        public void Setup()
        {
            listeners = new List<object>();
            context = new Mock<SynchronizationContext>();
            BeforeEachTest();
        }

        protected abstract void BeforeEachTest();

        protected IEventPublisher CreateSut()
        {
            return new EventBroker(context.Object, listeners);
        }
    }

    [TestFixture]
    public class When_a_message_is_published_by_the_EventBroker
        : EventBrokerAsPublisherSpec
    {
        private Mock<IListener<string>> listener;
        private const string MESSAGE = "test";

        protected override void BeforeEachTest()
        {
            listener = new Mock<IListener<string>>();
            listener.Setup(l => l.Handle(MESSAGE));

            listeners.Add(listener.Object);
            listeners.Add(new Mock<IListener<object>>().Object);
        }

        [Test]
        public void it_should_have_each_handler_handle_the_message()
        {
            CreateSut().Publish(MESSAGE);
            listener.Verify();
        }
    }
}
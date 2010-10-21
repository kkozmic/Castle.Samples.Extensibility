using Castle.Core;
using EventBrokerSample.UI.Infrastructure;
using EventBrokerSample.UI.Services;
using Moq;
using NUnit.Framework;

namespace EventBrokerSample.Tests.Infrstructure
{
    [TestFixture]
    public class when_the_RegisterWithEventBroker_concern_is_applied
    {
        private Mock<IEventRegister> register;

        [SetUp]
        public void Setup()
        {
            register = new Mock<IEventRegister>();
        }

        [Test]
        public void it_should_regsiter_the_object_in_the_event_register()
        {
            var model = new ComponentModel("", typeof (object), typeof (object));
            var component = new object();

            CreateSut().Apply(model, component);
            register.Verify(r => r.Register(component));
        }

        private ICommissionConcern CreateSut()
        {
            return new RegisterWithEventBroker(register.Object);
        }
    }
}
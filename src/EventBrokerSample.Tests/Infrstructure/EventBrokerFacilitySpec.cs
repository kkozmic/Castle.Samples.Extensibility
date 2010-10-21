// Copyright 2004-2010 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace EventBrokerSample.Tests.Infrstructure
{
	using System.Linq;

	using Castle.Core;
	using Castle.MicroKernel.Registration;
	using Castle.Windsor;

	using EventBrokerSample.UI.Facility;
	using EventBrokerSample.UI.Services;

	using Moq;

	using NUnit.Framework;

	[TestFixture]
	public class when_the_EventBrokerFacility_is_initailized
	{
		private const string LISTENER_KEY = "is listener";
		private const string NON_LISTENER_KEY = "is not listener";

		private IWindsorContainer container;

		[SetUp]
		public void Setup()
		{
			container = new WindsorContainer()
				.AddFacility<EventBrokerFacility>()
				.Register(Component
				          	.For<IListener<object>>()
				          	.Instance(new Mock<IListener<object>>().Object)
				          	.Named(LISTENER_KEY))
				.Register(Component
				          	.For<object>()
				          	.Instance(new object())
				          	.Named(NON_LISTENER_KEY));
		}

		[TearDown]
		public void TearDown()
		{
			container.Dispose();
		}

		[Test]
		public void it_should_apply_event_broker_commission_concerns_to_listeners()
		{
			var commissionConcerns = CreatSut(LISTENER_KEY).Lifecycle.CommissionConcerns;
			Assert.That(commissionConcerns.Count().Equals(1));
		}

		[Test]
		public void it_should_apply_event_broker_decommission_concerns_to_listeners()
		{
			var decommissionConcerns = CreatSut(LISTENER_KEY).Lifecycle.DecommissionConcerns;
			Assert.That(decommissionConcerns.Count().Equals(1));
		}

		[Test]
		public void it_should_not_apply_event_broker_commission_concerns_to_listeners()
		{
			var commissionConcerns = CreatSut(NON_LISTENER_KEY).Lifecycle.CommissionConcerns;
			Assert.That(commissionConcerns.Count().Equals(0));
		}

		[Test]
		public void it_should_not_apply_event_broker_decommission_concerns_to_listeners()
		{
			var decommissionConcerns = CreatSut(NON_LISTENER_KEY).Lifecycle.DecommissionConcerns;
			Assert.That(decommissionConcerns.Count().Equals(0));
		}

		private ComponentModel CreatSut(string key)
		{
			return container.Kernel.GetHandler(key).ComponentModel;
		}
	}
}
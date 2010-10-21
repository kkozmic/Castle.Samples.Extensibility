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

namespace Castle.Samples.Extensibility.Tests.Services
{
	using System.Collections.Generic;
	using System.Threading;

	using Castle.Samples.Extensibility.Services;

	using Moq;

	using NUnit.Framework;

	public abstract class EventBrokerAsRegisterSpec
	{
		protected Mock<SynchronizationContext> context;
		protected List<object> listeners;

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
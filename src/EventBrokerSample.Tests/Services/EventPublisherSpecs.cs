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

	public abstract class EventBrokerAsPublisherSpec
	{
		protected Mock<SynchronizationContext> context;
		protected List<object> listeners;

		protected abstract void BeforeEachTest();

		[SetUp]
		public void Setup()
		{
			listeners = new List<object>();
			context = new Mock<SynchronizationContext>();
			BeforeEachTest();
		}

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
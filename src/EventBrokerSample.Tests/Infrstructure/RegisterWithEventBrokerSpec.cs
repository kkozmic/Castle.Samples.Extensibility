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
	using Castle.Core;

	using EventBrokerSample.UI.Facility;
	using EventBrokerSample.UI.Services;

	using Moq;

	using NUnit.Framework;

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
			var model = new ComponentModel("", typeof(object), typeof(object));
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
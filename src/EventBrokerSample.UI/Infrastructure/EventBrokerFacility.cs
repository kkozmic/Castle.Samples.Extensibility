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

namespace EventBrokerSample.UI.Infrastructure
{
	using System.Collections.Generic;
	using System.Threading;
	using System.Windows.Forms;

	using Castle.MicroKernel.Facilities;
	using Castle.MicroKernel.Registration;

	using EventBrokerSample.UI.Services;

	public class EventBrokerFacility : AbstractFacility
	{
		protected override void Init()
		{
			Kernel.Register(Component
			                	.For<SynchronizationContext>()
			                	.ImplementedBy<WindowsFormsSynchronizationContext>()
			                	.LifeStyle.Singleton,
			                Component
			                	.For<IEventPublisher, IEventRegister>()
			                	.ImplementedBy<EventBroker>()
			                	.DependsOn(new { listeners = new List<object>() })
			                	.LifeStyle.Singleton);

			Kernel.ComponentModelBuilder.AddContributor(new EventBrokerContributor());
		}
	}
}
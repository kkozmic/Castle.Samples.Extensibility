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

namespace EventBrokerSample.UI.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;

	public class EventBroker : IEventPublisher, IEventRegister
	{
		private readonly SynchronizationContext context;
		private readonly IList<object> listeners;

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
			if (listeners.Contains(listener))
			{
				return;
			}
			listeners.Add(listener);
		}

		public void Unregister(object listener)
		{
			if (listeners.Contains(listener) == false)
			{
				return;
			}
			listeners.Remove(listener);
		}
	}
}
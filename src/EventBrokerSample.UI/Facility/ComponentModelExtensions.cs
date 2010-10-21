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

namespace EventBrokerSample.UI.Facility
{
	using System;
	using System.Linq;

	using Castle.Core;

	using EventBrokerSample.UI.Services;

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
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

namespace EventBrokerSample.UI
{
	using System.Windows.Forms;

	using Castle.Windsor;

	using EventBrokerSample.UI.Installers;
	using EventBrokerSample.UI.UI;

	internal class WindsorContext : ApplicationContext
	{
		private readonly IWindsorContainer container;

		public WindsorContext()
		{
			container = new WindsorContainer().Install(new EventBrokerInstaller(), new FormsInstaller());
			MainForm = container.Resolve<ApplicationShell>();
		}

		protected override void Dispose(bool disposing)
		{
			container.Dispose();
			base.Dispose(disposing);
		}
	}
}
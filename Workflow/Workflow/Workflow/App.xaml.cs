using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Workflow
{
	public partial class App : Application
	{
		public static App Instance => (App)Current;

		public readonly INavigationService NavigationService;
		public readonly IController Controller;

		public App ()
		{
			InitializeComponent();
			NavigationService = new NavigationService(new MainPage());
			
			Controller = new Controller(NavigationService);

		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

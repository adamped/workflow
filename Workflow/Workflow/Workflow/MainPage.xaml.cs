using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Workflow
{
	public class MainViewModel
	{
		public Command<string> NavigationCommand => new Command<string>((stateId) =>
		{
			App.Instance.Controller.Complete(new Result() { StateId = Convert.ToInt32(stateId) });
		});
	}

	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			BindingContext = new MainViewModel();
			InitializeComponent();
			
		}
	}
}

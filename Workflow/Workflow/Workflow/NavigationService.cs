using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Workflow
{

	public interface INavigationService
	{
		Task Push(Page page);
		Task Pop();
		Type CurrentPage { get; }
	}

    public class NavigationService: INavigationService
    {
		// This is just an example, it would be used to wire up to your MVVM
		// frameworks own Navigation Service.

		readonly NavigationPage _navigationPage; 

		public Type CurrentPage => _navigationPage?.CurrentPage?.GetType();

		public NavigationService(Page page)
		{
			Application.Current.MainPage = _navigationPage = new NavigationPage(page);
		}

		public async Task Push(Page page)
		{
			await _navigationPage.PushAsync(page);
		}

		public async Task Pop()
		{
			await _navigationPage.PopAsync();
		}

    }
}

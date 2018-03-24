using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Workflow
{

	public class Result
	{
		public int StateId { get; set; } = 0; // Optional StateId
		public object Parameter { get; set; } // Optional Data you want sending
		public static Result Empty() => new Result();
	}

	public interface IController
	{
		Task Complete(Result result);
		Task Cancel();
	}


	public class Controller : IController
	{
		readonly INavigationService _navigationService;
		public Controller(INavigationService navigationService)
		{
			_navigationService = navigationService;
			MapWorkflow();
		}
		struct Map
		{
			public static Map Create(int stateId, Type page)
			{
				return new Map()
				{
					StateId = stateId,
					Page = page
				};
			}
			public int StateId;
			public Type Page;
		}

		// From -> To
		IDictionary<Map, Type> _workflow = new Dictionary<Map, Type>();
	
		void MapWorkflow()
		{
			_workflow.Add(Map.Create(0, typeof(MainPage)), typeof(SecondPage));
			_workflow.Add(Map.Create(1, typeof(MainPage)), typeof(ThirdPage));
		}

		public async Task Complete(Result result)
		{
			var toPage = _workflow.First(x => x.Key.StateId == result.StateId && x.Key.Page == _navigationService.CurrentPage).Value;
			await _navigationService.Push((Page)Activator.CreateInstance(toPage));
		}

		public async Task Cancel()
		{
			await _navigationService.Pop();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;


namespace gina_api_examples2.Core.Services
{
	public class AllTestsService : IAllTestsService
	{
		MvxViewModel _currentViewModel;

		public IList<Type> All { get; private set; }


		public AllTestsService(MvxViewModel currentViewModel) {
			_currentViewModel = currentViewModel;

			All = typeof(AllTestsService).GetTypeInfo().Assembly.CreatableTypes()
				.Where(t => typeof (ViewModels.TestViewModel).IsAssignableFrom(t) && (t != typeof(ViewModels.TestViewModel)))
				.ToList();
		}


		public Type NextViewModelType()
		{
			var index = All.IndexOf(_currentViewModel.GetType());
			var nextIndex = index + 1;

			if (nextIndex < All.Count) {
				return All [nextIndex];
			}

			return null;
		}
	}
}


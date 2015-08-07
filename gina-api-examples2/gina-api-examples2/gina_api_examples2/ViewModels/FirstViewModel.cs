using System;
using System.Collections.Generic;
using System.Windows.Input;

using Cirrious.MvvmCross.ViewModels;


namespace gina_api_examples2.Core.ViewModels
{
	public class FirstViewModel : MvxViewModel 
	{

		private IList<Type> _tests;
		public IList<Type> Tests
		{
			get { return _tests; }
			set { _tests = value; RaisePropertyChanged(() => Tests); }
		}
			
		public FirstViewModel(Services.IAllTestsServiceFactory factory)
		{
			Tests = factory.GetAllTestsService(this).All;
		}

		public ICommand GotoTestCommand
		{
			get { return new MvxCommand<Type>(type => ShowViewModel(type)); }
		}
	}
}

using System;

using Cirrious.MvvmCross.ViewModels;


namespace gina_api_examples2.Core.Services
{
	public interface IAllTestsServiceFactory
	{
		IAllTestsService GetAllTestsService(MvxViewModel currentViewModel);
	}
}


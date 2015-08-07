using System;

using Cirrious.MvvmCross.ViewModels;


namespace gina_api_examples2.Core.Services
{
	public class AllTestsServiceFactory : IAllTestsServiceFactory
	{
		public IAllTestsService GetAllTestsService(MvxViewModel currentViewModel) {
			return new AllTestsService(currentViewModel);
		}
	}
}


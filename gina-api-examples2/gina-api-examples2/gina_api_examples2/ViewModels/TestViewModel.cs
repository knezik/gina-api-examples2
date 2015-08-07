using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using Cirrious.CrossCore;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.ViewModels;


namespace gina_api_examples2.Core.ViewModels
{
	public class TestViewModel : MvxViewModel
	{
		public ICommand NextCommand
		{
			get
			{
				return new MvxCommand(() =>
					{
						var factory = Mvx.Resolve<Services.IAllTestsServiceFactory>();
						var all = factory.GetAllTestsService(this);

						var next = all.NextViewModelType();
						if (next == null)
							Close(this);
						else
							ShowViewModel(next);
					});
			}
		}
	}
}


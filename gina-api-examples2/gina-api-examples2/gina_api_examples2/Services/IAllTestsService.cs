using System;
using System.Collections.Generic;


namespace gina_api_examples2.Core.Services
{
	public interface IAllTestsService
	{
		IList<Type> All { get; }	

		Type NextViewModelType();
	}
}


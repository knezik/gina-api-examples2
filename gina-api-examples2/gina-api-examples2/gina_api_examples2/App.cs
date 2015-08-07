using Cirrious.CrossCore.IoC;

namespace gina_api_examples2.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
			// services
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

			// factories
			CreatableTypes()
				.EndingWith("Factory")
				.AsInterfaces()
				.RegisterAsLazySingleton();
				
            RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}
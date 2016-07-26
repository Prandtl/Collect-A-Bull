using Collect_A_Bull.Core.Services.DataStore;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace Collect_A_Bull.Core
{
	public class App : MvvmCross.Core.ViewModels.MvxApplication
	{
		public override void Initialize()
		{
			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			CreatableTypes()
				.EndingWith("Repository")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			RegisterAppStart<ViewModels.HomeViewModel>();
		}
	}
}

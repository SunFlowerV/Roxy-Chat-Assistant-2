using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Roxy_Chat_Assistant.Model;
using Roxy_Chat_Assistant_2.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Roxy_Chat_Assistant_2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		public App()
		{
			Services = ConfigureServices();
		}

		public IServiceProvider Services { get; }

		private static IServiceProvider ConfigureServices()
		{
			var services = new ServiceCollection();

			services.AddDbContext<AppDbContext>();

			// Регистрируем ViewModels
			services.AddTransient<MainViewModel>();




			return services.BuildServiceProvider();
		}
	}

}

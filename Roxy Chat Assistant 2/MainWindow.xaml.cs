using MahApps.Metro.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Roxy_Chat_Assistant.Model;
using Roxy_Chat_Assistant_2.ViewModel;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Roxy_Chat_Assistant_2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = ((App)Application.Current).Services.GetRequiredService<MainViewModel>();
			if (DataContext is MainViewModel vm)
			{
				vm.ScrollToBottom += () =>
				{
					ChatScrollView.ScrollToEnd();
				};
			}
		}
	}
}
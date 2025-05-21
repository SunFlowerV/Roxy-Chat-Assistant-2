using Microsoft.EntityFrameworkCore;
using Roxy_Chat_Assistant.Model;
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
	public partial class MainWindow : Window
	{
		private readonly AppDbContext _db;

		public MainWindow()
		{
			InitializeComponent();
			_db = new AppDbContext(); // Или через сервис-локатор
		}

		private void OnButtonClicked(object sender, RoutedEventArgs e)
		{
			var randomQuestion = _db.Questions
				.OrderBy(q => EF.Functions.Random())
				.FirstOrDefault()?.Text;

			if (string.IsNullOrEmpty(randomQuestion)) return;

			// Создаем сообщение (аналог Frame + Label в MAUI)
			var messageBorder = new Border
			{
				Style = (Style)FindResource("ChatBubbleStyle"),
				HorizontalAlignment = HorizontalAlignment.Left,
				Opacity = 0,
				RenderTransform = new TranslateTransform { Y = 20 }
			};

			var label = new TextBlock
			{
				Text = randomQuestion,
				FontSize = 24,
				Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333")),
				TextWrapping = TextWrapping.Wrap,
				Width = 600
			};

			messageBorder.Child = label;
			ChatMessagesLayout.Children.Add(messageBorder);

			// Анимация (аналог FadeTo/TranslateTo в MAUI)
			var fadeIn = new DoubleAnimation(1, TimeSpan.FromMilliseconds(300));
			var slideUp = new DoubleAnimation(0, TimeSpan.FromMilliseconds(300))
			{
				EasingFunction = new SineEase { EasingMode = EasingMode.EaseOut }
			};

			messageBorder.BeginAnimation(OpacityProperty, fadeIn);
			messageBorder.RenderTransform.BeginAnimation(TranslateTransform.YProperty, slideUp);

			// Прокрутка к новому сообщению
			ChatScrollView.ScrollToEnd();
		}
	}
}
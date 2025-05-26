using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Roxy_Chat_Assistant.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace Roxy_Chat_Assistant_2.ViewModel
{
	public partial class MainViewModel : ObservableObject
	{

		private readonly AppDbContext _db;
		public partial class ChatMessage : ObservableObject
		{
			[ObservableProperty]
			private bool _isVisible;

			public string Text { get; set; } = string.Empty;
		}

		[ObservableProperty]
		private ObservableCollection<ChatMessage> _messages = new();

		public MainViewModel(AppDbContext db)
		{
			_db = db;
			// Приветственное сообщение
			AddMessage("Hi there! 😊 I'm Roxy — your fun little assistant who generates random words and questions to entertain or inspire you. Ready for a brain tickle?✨ Let's go! ⚡");
		}

		[RelayCommand]
		private async Task GenerateQuestion()
		{
			await AddMessage(GenerateRandomMessage());
		}

		private async Task AddMessage(string messageText)
		{
			var newMessage = new ChatMessage
			{
				Text = messageText,
				IsVisible = false
			};

			Messages.Add(newMessage);

			// Задержка перед анимацией
			await Task.Delay(50);
			newMessage.IsVisible = true;

			await Task.Delay(300); // Ждём завершения анимации
			ScrollToBottom?.Invoke();
		}

		private string GenerateRandomMessage()
		{
			var randomQuestion = _db.Questions
				.OrderBy(q => EF.Functions.Random())
				.FirstOrDefault()?.Text;

			if (string.IsNullOrEmpty(randomQuestion)) return "Ugh, I can't even talk about this right now—I haven't found the right question bank to process it yet. 😤";

			return randomQuestion;
		}

		public event Action ScrollToBottom;
	}
}

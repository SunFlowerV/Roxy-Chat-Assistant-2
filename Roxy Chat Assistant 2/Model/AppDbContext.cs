using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Roxy_Chat_Assistant.Model
{
	public class AppDbContext : DbContext
	{
		public DbSet<Question> Questions { get; set; }
		public DbSet<QuestionsBank> QuestionsBanks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			string appFolder = AppContext.BaseDirectory;
			string dbPath = Path.Combine(appFolder, "RoxyChatAssistantDb.db3");
			options.UseSqlite($"Filename={dbPath}").LogTo(Console.WriteLine, LogLevel.Information);
		}
	}
}

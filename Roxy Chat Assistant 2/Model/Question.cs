using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roxy_Chat_Assistant.Model
{
	public class Question
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int QuestionsBankId { get; set; }
		public QuestionsBank QuestionsBank { get; set; }
	}
}

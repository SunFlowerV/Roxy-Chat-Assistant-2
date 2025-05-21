using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roxy_Chat_Assistant.Model
{
	public class QuestionsBank
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Question> Questions { get; set; }
	}
}

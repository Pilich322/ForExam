using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewTestAndTeach.Data
{
	public class Book
	{
		public int bookId { get; set; }
		public string bookName { get; set; } // Имя автора
		public string dateCreate { get; set; } // Дата написания книги
		public int authorId { get; set; } //ID книги

		public virtual Author author { get; set; }
	}
}

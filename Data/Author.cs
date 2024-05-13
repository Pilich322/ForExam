using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ListViewTestAndTeach.Data
{
	public class Author
	{
		[JsonPropertyName("authorId")]
		public int Id { get; set; }

		[JsonPropertyName("authorFirstName")]
		public string FirstName { get; set; } // Имя
		[JsonPropertyName("authorLastName")]
		public string LastName { get; set; } // Фамилия
		[JsonPropertyName("authorSurName")]
		public string SurName { get; set; } // Отчество

		public override string ToString()
		{
			return  $"{LastName} {FirstName} {SurName}";
		}
	}
}

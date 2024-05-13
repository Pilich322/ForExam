using ListViewTestAndTeach.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ListViewTestAndTeach
{
    public class ApiManager
    {
        static string baseUrl = "https://localhost:7232";
        static HttpClient client = new HttpClient();
        public static async Task<List<Author>> GetAuthors()
        {
            HttpResponseMessage response = await client.GetAsync(baseUrl + "/author");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Author> authors = JsonSerializer.Deserialize<List<Author>>(responseBody);
            return authors;
        }
		public static async Task<Author> GetAuthor(int id)
		{
			HttpResponseMessage response = await client.GetAsync(baseUrl + "/author/" + id);
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			Author authors = JsonSerializer.Deserialize<Author>(responseBody);
			return authors;
		}
		public static async Task DeleteAuthor(int id)
		{
			HttpResponseMessage response = await client.DeleteAsync(baseUrl + "/author/" + id);
			response.EnsureSuccessStatusCode();
		}
		public static async Task CreateAuthor(Author author)
		{
			string json = JsonSerializer.Serialize(author);
			HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PostAsync(baseUrl + "/author",content);
			response.EnsureSuccessStatusCode();
		}
		public static async Task UpdateAuthor(Author author)
		{
			string json = JsonSerializer.Serialize(author);
			HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PutAsync(baseUrl + "/author/"+author.Id, content);
			response.EnsureSuccessStatusCode();
		}

		public static async Task<List<Book>> GetBooks()
		{
			HttpResponseMessage response = await client.GetAsync(baseUrl + "/books");
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			List<Book> books = JsonSerializer.Deserialize<List<Book>>(responseBody);
			return books;
		}
		public static async Task<Book> GetBook(int id)
		{
			HttpResponseMessage response = await client.GetAsync(baseUrl + "/books/"+id);
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			Book book = JsonSerializer.Deserialize<Book>(responseBody);
			return book;
		}
		public static async Task DeleteBook(int id)
		{
			HttpResponseMessage response = await client.DeleteAsync(baseUrl + "/books/" + id);
			response.EnsureSuccessStatusCode();
		}
		public static async Task CreateBook(Book book,int id)
		{
			string json = JsonSerializer.Serialize(book);
			HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PostAsync(baseUrl + $"/books/{id}", content);
			response.EnsureSuccessStatusCode();
		}
		public static async Task UpdateBook(Book book)
		{
			string json = JsonSerializer.Serialize(book);
			HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PutAsync(baseUrl + "/books/" + book.bookId, content);
			response.EnsureSuccessStatusCode();
		}
	}
}

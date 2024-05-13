using ListViewTestAndTeach.Data;
using ListViewTestAndTeach.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListViewTestAndTeach
{
	/// <summary>
	/// Логика взаимодействия для BookPage.xaml
	/// </summary>
	public partial class BookPage : Page
	{
		public BookPage()
		{
			InitializeComponent();
			AsyncInitializeComponent();
		}

		public async void AsyncInitializeComponent()
		{
			BooksList.ItemsSource = await GetBooks();
		}

		public async Task<List<Book>> GetBooks()
		{
			var books = await ApiManager.GetBooks();
			foreach (var book in books)
			{
				book.author = await ApiManager.GetAuthor(book.authorId);
			}
			return books;
		}

		private void BtBookDelItem_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var book = ((Control)sender).DataContext as Book;
				AsyncDeleteAuthor(book);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private async void AsyncDeleteAuthor(Book b)
		{
			await ApiManager.DeleteBook(b.bookId);
			AsyncInitializeComponent();
		}


		private void BtBookChangeItem_Click(object sender, RoutedEventArgs e)
		{
			App.MainFrame.Navigate(new BookInformation(((Control)sender).DataContext as Book));
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			AsyncInitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			App.MainFrame.Navigate(new BookInformation(null));
		}
    }
}

using ListViewTestAndTeach.Data;
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

namespace ListViewTestAndTeach.Pages
{
	/// <summary>
	/// Логика взаимодействия для BookInformation.xaml
	/// </summary>
	public partial class BookInformation : Page
	{
		private Book book = new Book();
		public BookInformation(Book newBook)
		{
			InitializeComponent();
			if (newBook != null)
				book = newBook;
			DataContext = book;
			AsyncInitializeComponent();
		}
		public async void AsyncInitializeComponent()
		{
			CBoxAuthors.ItemsSource = await GetAuthors();
			Author item = CBoxAuthors.Items.Cast<Author>().FirstOrDefault(a => a.Id == book.authorId);
			CBoxAuthors.SelectedItem = item;
		}
		public async Task<List<Author>> GetAuthors()
		{
			var authors = await ApiManager.GetAuthors();
			return authors;
		}

		private void BtSave_Click(object sender, RoutedEventArgs e)
		{
			SaveBook();
		}
		private async void SaveBook()
		{
			Author author = CBoxAuthors.SelectedItem as Author;
			book.authorId = author.Id;
			if (book.bookId == 0)
			{
				await ApiManager.CreateBook(book,book.authorId);
				App.MainFrame.GoBack();
			}
			else
			{
				await ApiManager.UpdateBook(book);
				App.MainFrame.GoBack();
			}
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			AsyncInitializeComponent();
		}

		private void TBoxDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			book.dateCreate = DPicker.Text;
		}
	}
}

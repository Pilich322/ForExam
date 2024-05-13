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
	/// Логика взаимодействия для AuthorsPage.xaml
	/// </summary>
	public partial class AuthorsPage : Page
	{
		public AuthorsPage()
		{
			InitializeComponent();
			AsyncInitializeComponent();
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			App.MainFrame.Navigate(new AuthorInformation(null));
		}
		public async void AsyncInitializeComponent()
		{
			AuthorsList.ItemsSource = await ApiManager.GetAuthors();
		}
		private void BtDelItem_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var author = ((Control)sender).DataContext as Author;
				AsyncDeleteAuthor(author);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void BtChangeItem_Click(object sender, RoutedEventArgs e)
		{
			App.MainFrame.Navigate(new AuthorInformation(((Control)sender).DataContext as Author));
		}

		private async void AsyncDeleteAuthor(Author a)
		{
			await ApiManager.DeleteAuthor(a.Id);
			AsyncInitializeComponent();
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			AsyncInitializeComponent();
		}
	}
}

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
	/// Логика взаимодействия для AuthorInformation.xaml
	/// </summary>
	public partial class AuthorInformation : Page
	{
		private Author author = new Author();
		public AuthorInformation(Author newAuthor)
		{
			InitializeComponent();
			if (newAuthor != null)
				author = newAuthor;
			DataContext = author;
		}

		private void BtSave_Click(object sender, RoutedEventArgs e)
		{
			SaveAuthor(author);
		}
		private async void SaveAuthor(Author author)
		{
			if(author.Id == 0)
			{
				await ApiManager.CreateAuthor(author);
				App.MainFrame.GoBack();
			}
			else
			{
				await ApiManager.UpdateAuthor(author);
				App.MainFrame.GoBack();	
			}
		}
	}
}

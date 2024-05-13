﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ListViewTestAndTeach.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ListViewTestAndTeach.Pages;

namespace ListViewTestAndTeach
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			App.MainFrame = MainFrame;
			App.MainFrame.Navigate(new AuthorsPage());
		}

		private void BtLoadBook_Click(object sender, RoutedEventArgs e)
		{
			App.MainFrame.Navigate(new BookPage());
		}

		private void BtLoadAuthors_Click(object sender, RoutedEventArgs e)
		{
			App.MainFrame.Navigate(new AuthorsPage());
		}
	}
}

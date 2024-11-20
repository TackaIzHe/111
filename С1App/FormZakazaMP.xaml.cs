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
using System.Windows.Shapes;

namespace С1App
{
	/// <summary>
	/// Логика взаимодействия для FormZakazaMP.xaml
	/// </summary>
	public partial class FormZakazaMP : Window
	{
		public FormZakazaMP(List<string> strings)
		{
			InitializeComponent();
			items.ItemsSource = strings;
			int total=0;
			foreach (var item in strings)
			{
				int i;
				int j;
				string i1 = item.Split(' ')[1];
				string j1 = item.Split(' ')[2];
				int.TryParse(i1, out i);
				int.TryParse(j1, out j);
				total += i*j;
			}
			TotalPrice.Text += total.ToString();
		}

		private void createZakaz(object sender, RoutedEventArgs e)
		{

		}
	}
}

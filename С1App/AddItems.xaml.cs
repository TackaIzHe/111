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
using С1App.Data;

namespace С1App
{
	/// <summary>
	/// Логика взаимодействия для AddItems.xaml
	/// </summary>
	public partial class AddItems : Window
	{
		public AddItems()
		{
			update();
			InitializeComponent();
		}
		async void update()
		{
			while(true)
			{
				await Task.Delay(1000);
				catt.ItemsSource = new C1DbContext().getCategories();
			}
		}

		private void addCatt(object sender, RoutedEventArgs e)
		{
			if(cattName.Text != "")
			{
				new C1DbContext().addCatt(cattName.Text);
			}
			else
			{
				MessageBox.Show("Имя не заполнено");
			}
        }

		private void addItem(object sender, RoutedEventArgs e)
		{
			new C1DbContext().addItem(new Item
			{
				Name = itemName.Text,
				Categoria = catt.Text,
				Price = Convert.ToInt32(itemPrice.Text),
				Colichestvo = Convert.ToInt32(itemCol.Text)
			});
		}
	}
}

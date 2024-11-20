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
	/// Логика взаимодействия для FormMP.xaml
	/// </summary>
	public partial class FormMP : Window
	{
		public List<Item> items1 {get;set;}
		public List<string> itemsInBuket = new List<string>();
		public FormMP()
		{
			InitializeComponent();
			items1 = new C1DbContext().getItems();
			listItemData(items1);
			cat.ItemsSource = new C1DbContext().getCategories();
			
			
		}
		async void update()
		{
			while(true)
			{
			await Task.Delay(1000);
				itemsOnBuy.ItemsSource = itemsInBuket;
			}
		}
		void listItemData(List<Item> items)
		{
			List<string> strings = new List<string>();
			foreach (Item item in items)
			{
				strings.Add(item.Name );
			}
			this.items.ItemsSource = strings;
		}

		private void zakazAction(object sender, RoutedEventArgs e)
		{
			new FormZakazaMP(itemsInBuket).Show();
        }

		private void itemOnBuy(object sender, RoutedEventArgs e)
		{
			int colli;
			int.TryParse(coll.Text, out colli);
			var item = items1.Find(x => x.Name==items.Text);
			if(coll.Text !="" && colli<=item.Colichestvo)
			{

			itemsInBuket.Add(item.Name + " " + item.Price + " " + coll.Text);
			itemsOnBuy.ItemsSource = null;
			itemsOnBuy.ItemsSource = itemsInBuket;
			items.Text = string.Empty;
			}
			else if(colli > item.Colichestvo)
			{
				MessageBox.Show("На складе недостаточно товара");
			}
			else
			{
				MessageBox.Show("ВВедите количество товара");
			}
		}

		private void setPriceAndColl(object sender, SelectionChangedEventArgs e)
		{
			if (items.SelectedValue != null)
			{
				var item = items1.Find(x => x.Name == items.SelectedValue.ToString());
				Price.Text = item.Price.ToString();
				Colichestvo.Text = item.Colichestvo.ToString();
			}
		}

		private void sort(object sender, RoutedEventArgs e)
		{
			if (items.SelectedValue == null)
			{
				listItemData(items1);
				return;
			}
			var sortItem = items1.FindAll(x => x.Categoria == cat.SelectedValue.ToString() && x.Price<=Convert.ToInt32(sortPrice.Text));
			listItemData(sortItem);
			items.SelectedValue = null;
		}
	}
}

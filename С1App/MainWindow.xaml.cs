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
using С1App.Data;

namespace С1App
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			new C1DbContext().AppContext();
			InitializeComponent();
		}



		private void loginAction(object sender, RoutedEventArgs e)
		{
			User user = new C1DbContext().authorize(login.Text, password.Text);
			if(user == null)
			{
				MessageBox.Show("Неверные данные");
				return;
			}
			else if(user.Role=="User")
			{
				new FormMP().Show();
			} 
			else if(user.Role=="Admin")
			{
				new AddItems().Show();
			}
		}

		private void registerAction(object sender, RoutedEventArgs e)
		{
			new RegForm().Show();
        }
    }
}

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
	/// Логика взаимодействия для RegForm.xaml
	/// </summary>
	public partial class RegForm : Window
	{
		public RegForm()
		{
			InitializeComponent();
		}

		private void Register(object sender, RoutedEventArgs e)
		{
			if(Name.Text=="" || Login.Text=="" || Password.Text=="" || Adress.Text=="")
			{
				MessageBox.Show("Вы заполнили не все поля");
					return;
			}
			else
			{

				new C1DbContext().addUser(new User 
				{
					Name=Name.Text,
					Login=Login.Text,
					Password=Password.Text,
					Adress=Adress.Text,
					Role="User"
				});
				MessageBox.Show("Вы зарегистрировались");
			}
        }
    }
}

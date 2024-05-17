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
using Borisov_pr_3.bd;

namespace Borisov_pr_3.Pages
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            if (tbFName.Text != "" && tbName.Text != "" && tbLogin.Text != "" && tbPassword.Text != "" && tbIDGroup.Text != "")
            {
                string name = tbName.Text.Trim();
                string fname = tbFName.Text.Trim();
                string login = tbLogin.Text.Trim();
                string pasw = tbPassword.Text.Trim();
                string pas = Hasha.Hash(pasw);
                string idg = tbIDGroup.Text.Trim();
                if (pasw.Length >= 6)
                {
                    bd.Model1 base1 = new bd.Model1();
                    var cl = base1.Client.Where(x => x.Login == login).FirstOrDefault();
                    if (cl == null)
                    {
                        bd.Client client = new bd.Client()
                        {Name = name, FName = fname, Login = login, Password = pas,IDGroup=idg };
                        base1.Client.Add(client);
                        base1.SaveChanges();
                        MessageBox.Show("Пользователь успешно зарегистрирован!");
                        NavigationService.Navigate(new Autho());
                    }
                    else { MessageBox.Show("Пользователь с таким Логиным уже создан"); }
                }
                else { MessageBox.Show("Пароль должен содержать не меньше 6 символов"); }
            }
            else
            {
                MessageBox.Show("Введите данные в каждую строку...");
            }
        }
    }
}

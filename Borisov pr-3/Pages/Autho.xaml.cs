using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Linq.Expressions;
using Borisov_pr_3.bd;


namespace Borisov_pr_3.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        Model1 base1 = new Model1();
        bd.Client client = new bd.Client();
        int security = 0;
        public Autho()
        {
            InitializeComponent();
            textBlockCaptcha.Visibility = Visibility.Hidden;
            txtCaptcha.Visibility = Visibility.Hidden;
            txtLogin.Text = "";
            txtPassword.Text = "";
        }
        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            txtLogin.Text = "";
            txtPassword.Text = "";
            if (security >= 3)
            {
                Block();
            }
            NavigationService.Navigate(new Guest());
        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

            if (txtLogin.Text != "" && txtPassword.Text != "")
            {
                string log = txtLogin.Text.Trim();
                string pasw = txtPassword.Text.Trim();
                string pas = Hasha.Hash(pasw);
                client = base1.Client.Where(p => p.Login == log).FirstOrDefault();
                if (client != null)
                {
                    if (client.Password == pas)
                    {
                        txtLogin.Text = "";
                        txtPassword.Text = "";
                        switch (client.IDGroup) {
                            case "1":
                                NavigationService.Navigate(new User1(client));
                                break;
                            case "2":
                                NavigationService.Navigate(new User2(client));
                                break;
                            case "3":
                                DateTime dat = DateTime.Now;
                                if (dat.Hour <= 19 && dat.Hour>=10)
                                {

                                    NavigationService.Navigate(new User3(client));
                                }
                                else { MessageBox.Show("Вы не можете приступить к работе в это время! "); }
                                break;
                            default:
                                NavigationService.Navigate(new Guest());
                                break;

                        }
                    }
                }
                else
                {
                    security++;
                    MessageBox.Show("пользователя с логином '" + log + "' не существует", "Предупреждение");
                    if (security >= 3)
                    {
                        Block();
                    }
                }
            }
            else 
            {
                security++;
                MessageBox.Show("Пожалуйста, введите логин и пароль", "Предупреждение");
                if (security>=3)
                {
                    Block();
                }
            }
        }

        public void Block()
        {
            string all= "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwyz1234567890";
            Random r = new Random();
            char su = ' ';
            string cap = "";
            for (int i =0;i<6;i++)
            {
                 su = all [r.Next(all.Length)];
                cap = cap +su;
            }
            textBlockCaptcha.Visibility = Visibility.Visible;
            txtCaptcha.Visibility = Visibility.Visible;

            txtLoginText.Visibility = Visibility.Hidden;
            txtPasswordText.Visibility = Visibility.Hidden;
            txtLogin.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
            textBlockCaptcha.Text = cap;
            btnEnter.Visibility = Visibility.Hidden;
            btnEnterGuests.Visibility = Visibility.Hidden;
            btnReg.Visibility = Visibility.Hidden;
            CaptchanAsync();
        }

        public void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (security >= 3)
            {
                Block();
            }
            else 
            { 
                NavigationService.Navigate(new Register()); 
            }
        }

        public async Task CaptchanAsync()
        {
            textBlockCaptcha.Visibility = Visibility.Hidden;
            txtCaptcha.Visibility = Visibility.Hidden;
            await Task.Factory.StartNew(() =>
            {
                for (int i = 10; i > 0; i--)
                {
                    //Каждую секунду вызывает метод для обновления текста
                    TimerBlock.Dispatcher.Invoke(() =>
                    {
                        TimerBlock.Text = $"подождите {i} сек";
                    });
                    Task.Delay(1000).Wait();//приостанавливает выполнение задачи на 1 секунду
                }
            });
            TimerBlock.Text = "";

            textBlockCaptcha.Visibility = Visibility.Visible;
            txtCaptcha.Visibility = Visibility.Visible;
        }
        private void txtCaptcha_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (txtCaptcha.Text == textBlockCaptcha.Text.Trim())
            {
                security = 0;
                btnEnter.Visibility = Visibility.Visible;
                btnEnterGuests.Visibility = Visibility.Visible;
                btnReg.Visibility = Visibility.Visible;
                txtLoginText.Visibility = Visibility.Visible;
                txtPasswordText.Visibility = Visibility.Visible;
                txtLogin.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Visible;

                textBlockCaptcha.Visibility = Visibility.Hidden;
                txtCaptcha.Visibility = Visibility.Hidden;
            }
        }

        private void btnauten_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new zabil());
        }
    }
}

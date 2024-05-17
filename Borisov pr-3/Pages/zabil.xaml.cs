using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для zabil.xaml
    /// </summary>
    public partial class zabil : Page
    {
        public zabil()
        {
            InitializeComponent();
            //Скрытие textbox и lable для ввода кода при отправке сообщения
            txtKod.Visibility = Visibility.Hidden;
            txtKodText.Visibility = Visibility.Hidden;
        }
        //Создание копии базы и таблицы для работы с данными внутри таблиц
        Model1 bd = new Model1();
        bd.Client client = new bd.Client();
        // переменная для двухвакторного кода которая будет генерироваться самостоятельно
        string cap="";
        //метод для отправки кода на введённую пользователем почту
        private async Task MailGoAsync(string Email, string cap)
        {
            try
            {
                //Введённая пользователем почта
                string mal = txtEmail.Text.Trim();
                //отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("Bananan2024ban@mail.ru", "Verification code");
                // кому отправляем
                MailAddress to = new MailAddress(mal);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Your code";
                // текст письма
                m.Body = $"<h2>Your code is: {cap}<h2>";
                // письмо представляет код html, так как в нём есть теги
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("Bananan2024ban@mail.ru", "bononon202bo4");
                smtp.EnableSsl = true;
                smtp.Send(m);

            }
            catch (Exception e) {MessageBox.Show(e.Message); }
        }

        private void btnEnter_Click_1(object sender, RoutedEventArgs e)
        {
            //Проверка пустых textbox
            if (txtLogin.Text != "")
            {
                if (txtEmail.Text != "")
                {
                    //проверка существование логина
                    var log = bd.Client.FirstOrDefault(x => x.Login == txtLogin.Text);
                    if (log != null)
                    {
                        //проверка, совподает ли логин с почтой
                        if (log.Email == txtEmail.Text)
                        {
                            //генерирование рандомного кода
                            string all = "1234567890";
                            Random r = new Random();
                            char su = ' ';
                            string cap = "";
                            for (int i = 0; i < 5; i++)
                            {
                                su = all[r.Next(all.Length)];
                                cap = cap + su;
                            }
                            //вызов метода для отправки сообщения
                            MailGoAsync(log.Email, cap);
                            MessageBox.Show($"Письмо с кодом отправлени на почту {txtEmail.Text}");
                            txtKod.Visibility = Visibility.Visible;
                            txtKodText.Visibility = Visibility.Visible;
                        }
                        else { MessageBox.Show("Логин и почта не совпадают!"); }
                    }
                    else { MessageBox.Show("Логин не найден!"); }
                }
                else { MessageBox.Show("Введите потчу"); }
            }
            else { MessageBox.Show("Введите логин"); }
        }
        /* Вызов метода при изменении текста кода */
        private void txtKod_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtKod.Text == cap)
            {
                
                MessageBox.Show("Код подтверждён!");
            }
        }
    }
}

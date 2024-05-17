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
    /// Логика взаимодействия для User1.xaml
    /// </summary>
    public partial class User1 : Page
    {
        public bd.Client client;
        public User1(bd.Client client1)
        {

            InitializeComponent();
            client = client1;
            ini();
        }
        bd.Model1 base1 = new bd.Model1();
        DateTime hour = DateTime.Now;


        private void ini()
        {
            if(hour.Hour>=10 && hour.Hour <= 19)
            {
                if (hour.Hour<=12)
                {
                    txtDay.Text = "Доброе Утро";
                }
                if (hour.Hour<=17)
                {
                    txtDay.Text = "Добрый День";
                }
                else { txtDay.Text = "Добрый Вечер"; }
            }
            txtHello.Text = client.Name + " " + client.FName;
        }



    }
}

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

namespace Borisov_pr_3.Pages
{
    /// <summary>
    /// Логика взаимодействия для Guest.xaml
    /// </summary>
    public partial class Guest : Page
    {
        public Guest()
        {
            InitializeComponent();
            ini();
        }
        DateTime hour = DateTime.Now;

        private void ini()
        {
            if (hour.Hour >= 10 && hour.Hour <= 19)
            {
                if (hour.Hour <= 12)
                {
                    txt.Text = "Доброе Утро Гость";
                }
                if (hour.Hour <= 17)
                {
                    txt.Text = "Добрый День Гость";
                }
                else { txt.Text = "Добрый Вечер Гость"; }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ООО_41Размер.Classes;
using ООО_41Размер.Models;

namespace ООО_41Размер.Windows
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
            Classes.ConstantData.auth = this;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {

            if (Login.Text.Length != 0 && Password.Text.Length != 0)
            {
                Users user = App.context.Users.ToList().Find(u => u.UserLogin == Login.Text && u.UserPassword == Password.Text);
                Roles roles = App.context.Roles.ToList().Find(r => r.RoleId == 1);
                if (user != null)
                {
                    AllData.ID = user.UserId;
                    Product win = new Product();
                    win.Show();
                    this.Close();
                }

                else
                    MessageBox.Show("Вы ввели неверные данные!");
            }
            else
                MessageBox.Show("Вы должны заполнить все поля!");
        }

        private void GuestEnter_Click(object sender, RoutedEventArgs e)
        {
            AllData.ID = 0;
            Product win = new Product();
            win.Show();
            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

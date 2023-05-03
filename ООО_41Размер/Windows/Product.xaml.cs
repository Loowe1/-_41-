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
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product : Window
    {
        public Product()
        {
            InitializeComponent();
            if (AllData.ID != 0)
            {
                Users user = App.context.Users.ToList().Find(u => u.UserId == AllData.ID);
                if (user.UserRole == 1)
                {
                    Add.Visibility = Visibility.Visible;
                    Edit.Visibility = Visibility.Visible;
                    Delete.Visibility = Visibility.Visible;
                }
            }
            LoadData();
            ConstantData.con.Close();
            ConstantData.con.Open();
        }

        private void Desc_Checked(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Asc_Checked(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Filtration_DropDownClosed(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            ProductView.Children.Clear();
            List<Models.Products> list = App.context.Products.ToList();
            if (Filtration.SelectedItem != null)
            {
                switch (Filtration.SelectedIndex)
                {
                    case 0:
                        list = App.context.Products.ToList();
                        break;
                    case 1:
                        list = list.Where(p => p.ProductDiscountAmount > 0 && p.ProductDiscountAmount < Convert.ToDecimal(9.99)).ToList();
                        break;
                    case 2:
                        list = list.Where(p => p.ProductDiscountAmount > 10 && p.ProductDiscountAmount < Convert.ToDecimal(14.99)).ToList();
                        break;
                    case 3:
                        list = list.Where(p => p.ProductDiscountAmount >= 15 && p.ProductDiscountAmount < 100).ToList();
                        break;
                }
            }
            if (Search.Text.Length != 0)
                list = list.Where(p => p.ProductName.Contains(Search.Text)).ToList();
            if (Asc.IsChecked == true)
                list = list.OrderBy(p => p.ProductCost).ToList();
            else if (Desc.IsChecked == true)
                list = list.OrderByDescending(p => p.ProductCost).ToList();

            foreach (var item in list)
                ProductView.Children.Add(new UserControlss.PriductCard(item.ProductArticleNumber, item.ProductName, item.ProductDescription, item.ProductManufacturer.ToString(), item.ProductCost.ToString(), Convert.ToDecimal(item.ProductDiscountAmount), item.ProductPhoto));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM Products WHERE ProductArticleNumber = '" + Classes.ConstantData.Atricle + "'", Classes.ConstantData.con);
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Невозможно удалить этот продукт!");
            }
            LoadData();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Autorization authorization = new Autorization();
            authorization.Show();
            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

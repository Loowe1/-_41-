using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ООО_41Размер.Models;

namespace ООО_41Размер.UserControlss
{
    /// <summary>
    /// Логика взаимодействия для PriductCard.xaml
    /// </summary>
    public partial class PriductCard : UserControl
    {
        string Article;
        public PriductCard(string Atricle, string Title, string Description, string Manufacture, string Cost, decimal Sale, byte[] Img)
        {
            InitializeComponent();
            this.Article = Atricle;
            this.Title.Text = Title;
            this.Description.Text = Description;
            Manufacturers manufacturers = App.context.Manufacturers.ToList().Find(m => m.ManufacturerId.ToString() == Manufacture);
            this.Manufacturer.Text += manufacturers.ProductManufacturer;
            this.Cost.Text += (Convert.ToDecimal(Cost) - Convert.ToDecimal(Cost) * Sale / 100).ToString().Split(',')[0] + " р.";
            if (Sale > 15)
                BackgroundSale.Background = SaleColor.Background;
            if (Sale > 0)
            {
                CostDiscount.Visibility = Visibility.Visible;
                CostDiscount.Text += Sale + "%";
            }

            try
            {
                BitmapImage img = new BitmapImage();
                MemoryStream MS = new MemoryStream(Img);
                img.BeginInit();
                img.StreamSource = MS;
                img.EndInit();
                this.Imgs.Source = img;
            }
            catch
            {
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Classes.ConstantData.Atricle = Article;
            MessageBox.Show("Продукт с артикулом " + Article + " выбран для работы!");
        }
    }
}

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

namespace Yastrebov_Glazki
{
    /// <summary>
    /// Логика взаимодействия для AddHistoryCostPage.xaml
    /// </summary>
    public partial class AddHistoryCostPage : Page
    {
        private ProductSale _currentProductSale = new ProductSale();
        Agent CurrentAgent;
        public AddHistoryCostPage(Agent agent)
        {
            InitializeComponent();
            CurrentAgent = agent;
            var products = Yastrebov_GlazkiSaveEntities.GetContext().Product.ToList();
            Products.ItemsSource = products;
            DataContext = _currentProductSale;
        }

        private void Products_TextChanged(object sender, TextChangedEventArgs e)
        {
            Products.IsDropDownOpen = true;
            var products = Yastrebov_GlazkiSaveEntities.GetContext().Product.ToList();
            products = products.Where(p => p.Title.ToLower().Contains(Products.Text.ToLower())).ToList();
            Products.ItemsSource = products;
        }
        private void SaveRecord_Click(object sender, RoutedEventArgs e)
        {


            StringBuilder errors = new StringBuilder();
            if (Products.SelectedItem == null)
                errors.AppendLine("укажите наименование продукта");
            if (ProductSaleDate.Text == "")
                errors.AppendLine("укажите дату продажи");
            if (_currentProductSale.ProductCount <= 0)
                errors.AppendLine("укажите количество продукции");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentProductSale.ID == 0)
                Yastrebov_GlazkiSaveEntities.GetContext().ProductSale.Add(_currentProductSale);
            Product selectedProduct = Products.SelectedItem as Product;

            _currentProductSale.AgentID = CurrentAgent.ID;
            _currentProductSale.ProductID = selectedProduct.ID;
            _currentProductSale.SaleDate = Convert.ToDateTime(ProductSaleDate.Text);
            _currentProductSale.ProductCount = Convert.ToInt32(ProductCount.Text);


            Yastrebov_GlazkiSaveEntities.GetContext().SaveChanges();
            MessageBox.Show("информация сохранена");
            Manager.MainFrame.GoBack();


        }
    }
}

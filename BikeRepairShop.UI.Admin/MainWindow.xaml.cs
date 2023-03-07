using BikeRepairShop.BL.Domain;
using BikeRepairShop.BL.DTO;
using BikeRepairShop.BL.Interfaces;
using BikeRepairShop.BL.Managers;
using BikeRepairShop.DL.Repositories;
using BikeRepairShop.UI.Admin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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

namespace BikeRepairShop.UI.Admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerManager customerManager;
        private ICustomerRepository customerRepo;
        private ObservableCollection<BikeUI> bikes;
        //TODO fix customer
        private ObservableCollection<string> customers;
        public MainWindow()
        {
            InitializeComponent();
            string conn = ConfigurationManager.ConnectionStrings["ADOconnSQL"].ConnectionString;
            customerRepo =new CustomerRepository(conn);
            customerManager = new CustomerManager(customerRepo);
            bikes=new ObservableCollection<BikeUI>(customerManager.GetBikesInfo().Select(x=>new BikeUI(x.Id,x.Description,x.BikeType,x.PurchaseCost,x.Customer.id,x.Customer.description)));
            customers = new ObservableCollection<string>(new List<string>() { "jos","janine","ivo"});
            BikeDataGrid.ItemsSource = bikes;
            BikeDataGrid.IsReadOnly= true;
        }

        private void MenuItemAddBike_Click(object sender, RoutedEventArgs e)
        {
            WindowBike w=new WindowBike(customerManager);
            w.CustomerComboBox.ItemsSource = customers;
            w.CustomerComboBox.SelectedIndex = 0;
            if (w.ShowDialog() == true)
            {
                bikes.Add(w.Bike);
            }
        }

        private void MenuItemDeleteBike_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("delbike");
        }

        private void MenuItemUpdateBike_Click(object sender, RoutedEventArgs e)
        {
            BikeUI bike = (BikeUI)BikeDataGrid.SelectedItem;
            if (bike == null) MessageBox.Show("no selection", "Bike");
            else
            {
                WindowBike w = new WindowBike(customerManager,true);
                w.Bike = bike;
                w.ShowDialog();
            }
        }
    }
}

using BikeRepairShop.BL.Domain;
using BikeRepairShop.BL.DTO;
using BikeRepairShop.BL.Managers;
using BikeRepairShop.UI.Admin.Mappers;
using BikeRepairShop.UI.Admin.Model;
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
using System.Windows.Shapes;

namespace BikeRepairShop.UI.Admin
{
    /// <summary>
    /// Interaction logic for WindowBike.xaml
    /// </summary>
    public partial class WindowBike : Window
    {
        public BikeUI Bike { get; set; }
        private bool update;
        private CustomerManager customerManager;
        public WindowBike(CustomerManager customerManager,bool update=false)
        {
            InitializeComponent();
            this.customerManager = customerManager;
            BikeTypeComboBox.ItemsSource=Enum.GetValues(typeof(BikeType));
            BikeTypeComboBox.SelectedIndex=0;
            this.update = update;
            if (update)
            {
                CustomerTextBox.Visibility= Visibility.Visible;
                CustomerComboBox.Visibility= Visibility.Collapsed;
            }
            else
            {
                CustomerTextBox.Visibility= Visibility.Collapsed;
                CustomerComboBox.Visibility= Visibility.Visible;
                IDTextBox.Text = "<generated>";
            }
        }

        private void CancelBikeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBikeButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO save to DL
            if (update)
            {                
                Bike.Description=DescriptionTextBox.Text;
                Bike.BikeType = (BikeType)BikeTypeComboBox.SelectedItem;
                Bike.PurchaseCost=double.Parse(PurchaseCostTextBox.Text);
                //customerManager.UpdateBike(Bike)
            }
            else //add
            {
                //Bike = new BikeUI(10, "kkkk", BikeType.regularBike, 120, 1, "josken");
                customerManager.AddBike(BikeMapper.ToDTO(Bike));
            }
            DialogResult = true;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (update)
            {
                CustomerTextBox.Text = "jos";
                BikeTypeComboBox.SelectedItem = Bike.BikeType;
                DescriptionTextBox.Text = Bike.Description;
                IDTextBox.Text=Bike.Id.ToString();
                PurchaseCostTextBox.Text=Bike.PurchaseCost.ToString();
            }
        }
    }
}

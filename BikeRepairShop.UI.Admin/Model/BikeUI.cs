using BikeRepairShop.BL.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.UI.Admin.Model
{
    public class BikeUI : INotifyPropertyChanged
    {
        public int? Id { get; set; } //bikeID
        private string description;
        public string Description { get { return description; } set { description = value; OnPropertyChanged(); } }
        private BikeType bikeType;
        public BikeType BikeType { get { return bikeType; } set { bikeType = value; OnPropertyChanged(); }  }
        private double purchaseCost;

        public BikeUI(int? id, string description, BikeType bikeType, double purchaseCost, int customerId, string customerDescription)
        {
            Id = id;
            Description = description;
            BikeType = bikeType;
            PurchaseCost = purchaseCost;
            CustomerId = customerId;
            CustomerDescription = customerDescription;
        }

        public double PurchaseCost { get { return purchaseCost; } set { purchaseCost = value; OnPropertyChanged(); } }
        public int CustomerId { get; set; }
        public string CustomerDescription { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string name=null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

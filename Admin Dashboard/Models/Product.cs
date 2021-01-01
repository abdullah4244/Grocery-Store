using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Admin_Dashboard.Models
{
    class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; OnPropertyChanged("ID"); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged("Price"); }
        }
        private int quantity;
        public int Quantity
        {
            get { return quantity ; }
            set { quantity = value; OnPropertyChanged("Quantity"); }
        }

    }
}

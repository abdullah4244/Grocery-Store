using Admin_Dashboard.Commands;
using Admin_Dashboard.DataLayers;
using Admin_Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Admin_Dashboard.ViewModels
{
    class ClassViewModel
    {
        public ObservableCollection<Product> productlist;
        public ObservableCollection<Product> stacklist;
        public DelegateCommand AddCommand;
        ProductDataLayer data;
        public string ID { get; set; }
        public string Quanitity { get; set; }

        public ClassViewModel()
        {
            AddCommand = new DelegateCommand(Add, canAdd);
            stacklist = new ObservableCollection<Product>();
            data = new ProductDataLayer();
            productlist = data.getallProducts();
          
        }

        public bool canAdd(object o)
        {
            if (string.IsNullOrEmpty(ID))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ShowReciept()
        {
            int price = 0;
            for(int i=0;i<stacklist.Count;i++)
            {
                price += stacklist[i].Price;
            }
            MessageBox.Show($"Your total bill is{ price}");
        }
        public void Add(object o)
        {
            try
            {
                bool check = false;
                int id = Int32.Parse(ID);
                int quantity = Int32.Parse(Quanitity);

                for(int i = 0; i < productlist.Count; i++)
                {
                    if(id == productlist[i].ID && quantity <= productlist[i].Quantity)
                    {
                        stacklist.Add(new Product { ID = id, Quantity = quantity ,Price =quantity*productlist[i].Price });
                        productlist[i].Quantity -= quantity;
                        check = true;

                        break;
                    }
                }
                if(check == false)
                {
                    MessageBox.Show("Wrong Credentials");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Wrong Credetentials");
            }

        }
            
    }
}

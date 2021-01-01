using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Admin_Dashboard.Commands;
using System.Windows;
using Admin_Dashboard.Models;
using Admin_Dashboard.Views;

namespace Admin_Dashboard.ViewModels
{
    class AdminViewModel
    {
        public string ID { get; set; }
        public string IDdelete { get; set; }
        public string Name { get; set; }

        public string Price { get; set; }

       public ObservableCollection<Product> productlist;
        public string Quantity { get; set; }
        public AdminService admin;
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        //public DelegateCommand ProductsCommand { get; set; }

        public AdminViewModel()
        {
            AddCommand = new DelegateCommand(Add, canAdd);
            DeleteCommand = new DelegateCommand(Delete, canDelete);
           // ProductsCommand = new DelegateCommand(Show,canShow);
            admin = new AdminService();
            productlist = admin.GetAllProducts();

        }

        public void Delete(object o)
        {
            try
            {
                int id = Int32.Parse(IDdelete);
                if (admin.DeleteProduct(id))
                {
                    MessageBox.Show("Product Successfully Deleted");
                }
                else
                {
                    MessageBox.Show("Product ID not Found");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Enter valid ID (Must be integer");
            }

        }

        public bool canShow(object o)
        {
            return true;

        }

        public void Show (object o)
        {
            productlist = admin.GetAllProducts();
           
        }

        public bool canDelete(object o)
        {
            if (string.IsNullOrEmpty(IDdelete))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Add(object o)
        {
            try
            {
                int id = Int32.Parse(ID);
                int price = Int32.Parse(Price);
                int quantity = Int32.Parse(Quantity);
                Product p = new Product { ID = id, Name = Name, Price = price, Quantity = quantity };
                if (admin.AddProduct(p))
                {
                    MessageBox.Show("Product Successfully Added");
                }
                else
                {
                    MessageBox.Show("Product Not added");
                }
            }
            catch
            {
                MessageBox.Show("You must have Entered Wrong Value in ID,Price or Quantity Section(must enter a integer)");
            }
        }

        public bool canAdd(object o)
        {
            if(string.IsNullOrEmpty(ID)||string.IsNullOrEmpty(Name)||string.IsNullOrEmpty(Price) || string.IsNullOrEmpty(Quantity)){
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}

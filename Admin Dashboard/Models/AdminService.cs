using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Admin_Dashboard.DataLayers;

namespace Admin_Dashboard.Models
{
    class AdminService
    {
        ObservableCollection<Product> productlist;
       public AdminService()
        {
            productlist = new ObservableCollection<Product>();
        }
        public bool AddProduct(Product p)
        {
            ProductDataLayer data = new ProductDataLayer();
            return data.AddProductData(p);

        }

        public bool DeleteProduct(int id)
        {
            ProductDataLayer data = new ProductDataLayer();
            return data.DeleteProductData(id);
        }

        public ObservableCollection<Product> GetAllProducts()
        {
            ProductDataLayer data = new ProductDataLayer();
            return productlist = data.getallProducts();
        }
    }
}

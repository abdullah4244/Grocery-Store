using Admin_Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;

namespace Admin_Dashboard.DataLayers
{
    class ProductDataLayer
    {
        public Boolean AddProductData(Product p)
        {
            try
            {
                string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection connection = new SqlConnection(conString);
                int id = p.ID;
                string name = p.Name;
                int price = p.Price;
                int quantity = p.Quantity;

                string query = $"insert into Products(id,name,price,quantity) values({id},'{name}',{price},{quantity})";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                int insertedrows = cmd.ExecuteNonQuery();
                if (insertedrows >= 1)
                {
                    connection.Close();
                    return true;
                }

                else
                {
                    connection.Close();
                    return false;
                }

            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool DeleteProductData(int id)
        {
            try
            {
                string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection connection = new SqlConnection(conString);
                int id2 = id;
               

                string query = $"delete from Products where id = {id2}";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                int insertedrows = cmd.ExecuteNonQuery();
                if (insertedrows >= 1)
                {
                    connection.Close();
                    return true;
                }

                else
                {
                    connection.Close();
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public ObservableCollection<Product> getallProducts()
        {
            ObservableCollection<Product> tmplist = new ObservableCollection<Product>();
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            string query = "Select * from Products";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product p = new Product();
                p.ID =(Int32) dr[0];
                p.Name = dr[1].ToString();
                p.Price=(Int32) dr[2];
                p.Quantity = (Int32)dr[3];

                tmplist.Add(p);

            }

            connection.Close();
            return tmplist;

        }
    }
}

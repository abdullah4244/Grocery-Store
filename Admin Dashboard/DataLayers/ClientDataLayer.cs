using System;
using System.Collections.Generic;
using System.Text;
using Admin_Dashboard.Models;
using Microsoft.Data.SqlClient;

namespace Admin_Dashboard.DataLayers
{
    class ClientDataLayer
    {
        public bool ClientSignUp(Client c)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(conString);
            string name = c.Username;
            string pass = c.Password;
            string query = $"insert into Clients(name,password) values('{name}','{pass}')";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
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

        public bool Login(string name,string password)
        {
            int ID;
            string namee;
            string pass;
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            string query = "Select * from Clients";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product p = new Product();
                  ID = (Int32)dr[0];
                namee = dr[1].ToString();
                 pass = dr[2].ToString();
             
                if(name.Equals(name) && pass.Equals(password))
                {
                    connection.Close();
                    return true;
                }
                

            }

            connection.Close();
            return false;
        }
    }
}

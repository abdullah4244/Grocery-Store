using Admin_Dashboard.Commands;
using Admin_Dashboard.Models;
using Admin_Dashboard.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Admin_Dashboard.ViewModels
{
    class ClientLoginViewModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand LoginCommand { get; set; }

        public ClientLoginService client;
        public ClientLoginViewModel()
        {
            AddCommand = new DelegateCommand(Add, canAdd);
            
            client = new ClientLoginService();
        }

        public void Add(object o)
        {
            Client c = new Client { Username = Name, Password = Password };
            if (client.AddClient(c))
            {
                MessageBox.Show("Signup Succesfull");
            }
            else
            {
                MessageBox.Show("Signup Not Succesfull");
            }
        }

        public bool canAdd(object o)
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Login()
        {
            if (client.Login(LoginName, LoginPassword)){

                return true;
             
            }
            else
            {
                return false;
            }
        }

        public bool canLogin(object o)
        {
            if (string.IsNullOrEmpty(LoginName)|| string.IsNullOrEmpty(LoginPassword))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

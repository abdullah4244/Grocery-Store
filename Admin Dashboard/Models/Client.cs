using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Admin_Dashboard.Models
{
    class Client : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value;OnPropertyChanged("Password"); }
        }
    }
}

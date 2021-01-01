using Admin_Dashboard.DataLayers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_Dashboard.Models
{
    class ClientLoginService
    { 
        public bool AddClient(Client c)
        {
            ClientDataLayer data = new ClientDataLayer();
            return data.ClientSignUp(c);
        }

        public bool Login(string name, string password)
        {
            ClientDataLayer data = new ClientDataLayer();
            return data.Login(name, password);
        }
    }
}

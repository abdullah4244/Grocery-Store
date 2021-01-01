using Admin_Dashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Admin_Dashboard.Views
{
    /// <summary>
    /// Interaction logic for ClientLoginView.xaml
    /// </summary>
    public partial class ClientLoginView : UserControl
    {
        ClientLoginViewModel v = new ClientLoginViewModel();
        public ClientLoginView()
        {
            InitializeComponent();
          
            this.DataContext = v;
            
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (v.Login())
            {
                MainWindow w = new MainWindow();
                w.Content = new ClientdashboardView();
                w.Show();
                Window.GetWindow(this).Close();
            }
        }
    }
}

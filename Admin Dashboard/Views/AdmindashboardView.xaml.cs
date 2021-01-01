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
    /// Interaction logic for AdmindashboardView.xaml
    /// </summary>
    public partial class AdmindashboardView : UserControl
    {
        public AdmindashboardView()
        {
            InitializeComponent();
            this.DataContext = new AdminViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Window.GetWindow(this).Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Content = new ProductsListView();
            w.Show();

        }
    }
}

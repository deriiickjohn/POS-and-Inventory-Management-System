using POS_and_Inventory_Management_System.Windows;
using System.Windows;

namespace POS_and_Inventory_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainPage : Window
    {

        Login login;
        public MainPage(Login l)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            login = l;

            //usernameDisplay.Content = Username;


        }


        private void manageProduct_Click(object sender, RoutedEventArgs e)
        {
            ManageProduct manageProductWindow = new ManageProduct();
            manageProductWindow.ShowDialog();

        }
        private void manageBrandButton_Click(object sender, RoutedEventArgs e)
        {
            ManageBrand manageBrandWindow = new ManageBrand();
            manageBrandWindow.ShowDialog();
        }

        private void manageCategory_Click(object sender, RoutedEventArgs e)
        {
            ManageCategory manageCategoryWindow = new ManageCategory();
            manageCategoryWindow.ShowDialog();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {

            Login loginPage = new Login();
            loginPage.Show();
            this.Close();
        }

        private void manageStock_Click(object sender, RoutedEventArgs e)
        {
            ManageStock manageStockWindow = new ManageStock();
            manageStockWindow.ShowDialog();
        }

        private void manageUserButton_Click(object sender, RoutedEventArgs e)
        {
            ManageUser manageUserWindow = new ManageUser();
            manageUserWindow.ShowDialog();
        }

        private void managePOS_Click(object sender, RoutedEventArgs e)
        {
            POS managePOS = new POS();
            managePOS.ShowDialog();
        }
    }
}

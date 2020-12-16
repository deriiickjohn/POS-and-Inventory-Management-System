using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace POS_and_Inventory_Management_System.Windows
{
    /// <summary>
    /// Interaction logic for ManageBrand.xaml
    /// </summary>
    public partial class ManageBrand : Window
    {
        SqlConnection cn;
        DBConnection dbCon = new DBConnection();
        DataTable dt = new DataTable();
        public ManageBrand()
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            cn = new SqlConnection(dbCon.Connection());
            try
            {
                cn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection problem: Please check connection to the DataBase");
            }

        }

        private void UpdateGrid()
        {

            dt.Clear();


            SqlCommand com = cn.CreateCommand();
            com.CommandText = "SELECT Id,Name,Address,Contact,Email FROM Brand";
            com.CommandType = CommandType.Text;

            SqlDataReader dr = com.ExecuteReader();
            dt.Load(dr);



            dataGridBrand.ItemsSource = dt.DefaultView;



        }

        private void AddUpdateDelete(string sqlStatement, string state)
        {


            string msg = "";
            SqlCommand com = cn.CreateCommand();
            com.CommandText = sqlStatement;
            com.CommandType = CommandType.Text;

            switch (state)
            {
                case "Add":
                    msg = "Data Inserted Successfully!";
                    com.Parameters.Add("Name", SqlDbType.VarChar, 50).Value = textBoxBRandName.Text;
                    com.Parameters.Add("Address", SqlDbType.VarChar, 50).Value = textBoxAddress.Text;

                    try
                    {
                        com.Parameters.Add("Contact", SqlDbType.Int, 4).Value = Int32.Parse(textBoxContactNumber.Text);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("eh");
                    }
                    com.Parameters.Add("Email", SqlDbType.VarChar, 50).Value = textBoxBRandName.Text;
                    break;
                case "Update":
                    msg = "Data Updated Successfully!";
                    com.Parameters.Add("Name", SqlDbType.VarChar, 50).Value = textBoxBRandName.Text;
                    com.Parameters.Add("Address", SqlDbType.VarChar, 50).Value = textBoxAddress.Text;
                    com.Parameters.Add("Contact", SqlDbType.Int, 4).Value = Int32.Parse(textBoxContactNumber.Text);
                    com.Parameters.Add("Email", SqlDbType.VarChar, 50).Value = textBoxEmail.Text;
                    com.Parameters.Add("Id", SqlDbType.Int, 4).Value = Int32.Parse(labelBrandIDModify.Text);
                    break;
                case "Delete":
                    msg = "Data Deleted Successfully!";
                    com.Parameters.Add("Id", SqlDbType.Int, 4).Value = Int32.Parse(labelBrandIDModify.Text);
                    break;
            }

            try
            {
                int n = com.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.UpdateGrid();
                }
            }
            catch (Exception)
            {
                textBoxContactNumber.Text = "";
                this.InitializedButtonState();
            }



        }

        private void dataGridBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;


            //MessageBox.Show(dr[2].ToString());

            if (dr != null)
            {

                labelBrandIDModify.Text = dr["Id"].ToString();
                textBoxBRandName.Text = dr["Name"].ToString();
                textBoxAddress.Text = dr["Address"].ToString();
                textBoxContactNumber.Text = dr["Contact"].ToString();
                textBoxEmail.Text = dr["Email"].ToString();

                buttonAddBrand.IsEnabled = false;
                buttonUpdateBrand.IsEnabled = true;
                buttonDeleteBrand.IsEnabled = true;
            }
        }

        private void buttonAddBrand_Click(object sender, RoutedEventArgs e)
        {

            string sql = "INSERT INTO Brand(Name,Address,Contact,Email) VALUES (@Name,@Address,@Contact,@Email)";

            TextBox[] textBoxArray = { textBoxBRandName, textBoxContactNumber, textBoxAddress, textBoxEmail };


            if (textBoxArray[0].Text != ""
                && textBoxArray[1].Text != ""
                && textBoxArray[2].Text != ""
                && textBoxArray[3].Text != "")
            {
                this.AddUpdateDelete(sql, "Add");
                this.InitializedButtonState();
                this.Clear();
            }
            else
            {
                MessageBox.Show("Please complete details.");
            }
        }

        private void buttonUpdateBrand_Click(object sender, RoutedEventArgs e)
        {
            string sql = "UPDATE Brand SET Name = @Name, Address = @Address, Contact = @Contact, Email = @Email WHERE Id = @Id";
            this.AddUpdateDelete(sql, "Update");
            this.Clear();
        }

        private void buttonDeleteBrand_Click(object sender, RoutedEventArgs e)
        {
            string sql = "DELETE FROM Brand WHERE Id = @Id";
            this.AddUpdateDelete(sql, "Delete");
            this.Clear();
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            this.Clear();
        }

        private void Clear()
        {

            labelBrandIDModify.Text = "";
            textBoxBRandName.Text = "";
            textBoxAddress.Text = "";
            textBoxContactNumber.Text = "";
            textBoxEmail.Text = "";

            this.InitializedButtonState();
        }

        private void InitializedButtonState()
        {
            buttonAddBrand.IsEnabled = true;
            buttonUpdateBrand.IsEnabled = false;
            buttonDeleteBrand.IsEnabled = false;
        }
        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.UpdateGrid();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            cn.Close();
        }

        private void textBoxSearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView dv = new DataView(dt);

            dv.RowFilter = string.Format("Name LIKE '%{0}%'", textBoxSearchName.Text);
            dataGridBrand.ItemsSource = dv;


        }
    }
}

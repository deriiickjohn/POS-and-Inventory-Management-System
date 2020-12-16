using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace POS_and_Inventory_Management_System.Windows
{
    /// <summary>
    /// Interaction logic for ManageCategory.xaml
    /// </summary>
    /// 

    public partial class ManageCategory : Window
    {

        SqlConnection cn;
        DBConnection dbCon = new DBConnection();
        DataTable dt = new DataTable();
        DataView dv;

        public ManageCategory()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            cn = new SqlConnection(dbCon.Connection());
            dv = new DataView(dt);

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
            com.CommandText = "SELECT Id,Name,Type,Unit FROM Category";
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
                    msg = "Data Inserted Successfully";
                    com.Parameters.Add("Name", SqlDbType.NVarChar, 50).Value = textBoxCategoryName.Text;
                    com.Parameters.Add("Type", SqlDbType.NVarChar, 50).Value = textBoxType.Text;
                    com.Parameters.Add("Unit", SqlDbType.NVarChar, 50).Value = textBoxUnit.Text;
                    break;
                case "Update":
                    msg = "Data Updated Successfully";
                    com.Parameters.Add("Name", SqlDbType.NVarChar, 50).Value = textBoxCategoryName.Text;
                    com.Parameters.Add("Type", SqlDbType.NVarChar, 50).Value = textBoxType.Text;
                    com.Parameters.Add("Unit", SqlDbType.NVarChar, 50).Value = textBoxUnit.Text;
                    com.Parameters.Add("Id", SqlDbType.Int, 4).Value = Int32.Parse(labelCategoryIDModify.Text);

                    break;
                case "Delete":
                    msg = "Data Deleted Successfully!";
                    com.Parameters.Add("Id", SqlDbType.Int, 4).Value = Int32.Parse(labelCategoryIDModify.Text);
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

                this.InitializedButtonState();
            }

        }







        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {

        }

        private void dataGridBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;

            if (dr != null)
            {

                labelCategoryIDModify.Text = dr["Id"].ToString();
                textBoxCategoryName.Text = dr["Name"].ToString();
                textBoxType.Text = dr["Type"].ToString();
                textBoxUnit.Text = dr["Unit"].ToString();

                buttonAddCategory.IsEnabled = false;
                buttonUpdateCategory.IsEnabled = true;
                buttonDeleteCategory.IsEnabled = true;
            }
        }

        private void buttonAddCategory_Click(object sender, RoutedEventArgs e)
        {

            string sql = "INSERT INTO Category(Name,Type,Unit) VALUES (@Name,@Type,@Unit)";
            TextBox[] textBoxArray = { textBoxCategoryName, textBoxType, textBoxUnit };


            if (textBoxArray[0].Text != ""
                && textBoxArray[1].Text != ""
                && textBoxArray[2].Text != ""
            )
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


        private void InitializedButtonState()
        {
            buttonAddCategory.IsEnabled = true;
            buttonUpdateCategory.IsEnabled = false;
            buttonDeleteCategory.IsEnabled = false;
        }

        private void Clear()
        {

            labelCategoryIDModify.Text = "";
            textBoxCategoryName.Text = "";
            textBoxType.Text = "";
            textBoxUnit.Text = "";


            this.InitializedButtonState();
        }

        private void buttonUpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            string sql = "UPDATE Category SET Name = @Name, Type = @Type, Unit = @Unit WHERE Id = @Id";
            this.AddUpdateDelete(sql, "Update");
            this.Clear();

        }

        private void buttonDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            string sql = "DELETE FROM Category WHERE Id = @Id";
            this.AddUpdateDelete(sql, "Delete");
            this.Clear();
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            this.Clear();
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


            dv.RowFilter = string.Format("Name LIKE '%{0}%'", textBoxSearchName.Text);
            dataGridBrand.ItemsSource = dv;
        }

        private void textBoxSearchType_TextChanged(object sender, TextChangedEventArgs e)
        {

            dv.RowFilter = string.Format("Type LIKE '%{0}%'", textBoxSearchType.Text);
            dataGridBrand.ItemsSource = dv;
        }

        private void textBoxSearchUnit_TextChanged(object sender, TextChangedEventArgs e)
        {

            dv.RowFilter = string.Format("Unit LIKE '%{0}%'", textBoxSearchUnit.Text);
            dataGridBrand.ItemsSource = dv;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace POS_and_Inventory_Management_System.Windows
{
    /// <summary>
    /// Interaction logic for ManageProduct.xaml
    /// </summary>
    public partial class ManageProduct : Window
    {
        SqlConnection cn;
        DBConnection dbCon = new DBConnection();

        SqlDataReader dr;
        DataTable dt = new DataTable();


        string BID, CID;

        List<string> PCodeList;



        public ManageProduct()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            cn = new SqlConnection(dbCon.Connection());

            cn.Open();

            LoadBrand();

            LoadCategory();


        }


        private void UpdateGrid()
        {

            dt.Clear();

            SqlCommand com = cn.CreateCommand();
            com.CommandText = "select p.PCode, p.PDesc, b.Name as BrandName, c.Name as CategoryName, p.Price from Product as p inner join Brand as b on b.Id = p.BrandId inner join Category as c on c.Id = p.CategoryId  where p.PDesc like '%' ";
            com.CommandType = CommandType.Text;

            SqlDataReader read = com.ExecuteReader();
            dt.Load(read);
            dataGridProduct.ItemsSource = dt.DefaultView;

        }

        private void dataGridProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView row = dg.SelectedItem as DataRowView;

            if (row != null)
            {

                textBoxProductCode.Text = row["PCode"].ToString();
                // textBoxBarCode.Text = row["Barcode"].ToString();
                textBoxDesc.Text = row["PDesc"].ToString();
                textBoxPrice.Text = row["Price"].ToString();
                //textBoxQty.Text = row["Qty"].ToString();
                comboBoxBrand.Text = row["BrandName"].ToString();
                comboBoxCategory.Text = row["CategoryName"].ToString();
            }


            textBoxProductCode.IsEnabled = false;
            buttonAddProduct.IsEnabled = false;
            buttonUpdateProduct.IsEnabled = true;
            buttonDeleteProduct.IsEnabled = true;


        }
        private void AddUpdateDelete(string sqlStatement, string state)
        {

            string msg = "";

            SqlCommand com = cn.CreateCommand();
            com.CommandText = sqlStatement;
            com.CommandType = CommandType.Text;


            if (state == "Add" || state == "Update")
            {
                com.Parameters.Add("PCode", SqlDbType.VarChar, 50).Value = textBoxProductCode.Text;
                com.Parameters.Add("Barcode", SqlDbType.VarChar, 50).Value = 0;
                com.Parameters.Add("PDesc", SqlDbType.VarChar, 255).Value = textBoxDesc.Text;
                com.Parameters.Add("BrandId", SqlDbType.Int, 4).Value = GetBrandID();
                com.Parameters.Add("CategoryId", SqlDbType.Int, 4).Value = GetCategoryID();
                try
                {
                    com.Parameters.Add("Price", SqlDbType.Decimal, 9).Value = Decimal.Parse(textBoxPrice.Text);
                }
                catch (Exception)
                {

                    MessageBox.Show("(Price) : Please input a valid decimal value.");
                }
                com.Parameters.Add("Qty", SqlDbType.Int, 4).Value = 0;

                if (state == "Add") msg = "Data Inserted Successfully";
                else if (state == "Update") msg = "Data Updated Successfully";

            }
            else if (state == "Delete")
            {
                com.Parameters.Add("PCode", SqlDbType.VarChar, 50).Value = textBoxProductCode.Text;
                msg = "Data Deleted Successfully";
            }


            try
            {
                int n = com.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.UpdateGrid();
                    this.InitializedButtonState();
                    this.Clear();
                }
            }
            catch (Exception)
            {

            }

        }

        private void buttonAddProduct_Click(object sender, RoutedEventArgs e)
        {


            if (GetProductCodeItems().Contains(textBoxProductCode.Text))
            {
                MessageBox.Show("enter dif");
            }
            else
            {

                if (textBoxProductCode.Text != "" &&
                        textBoxPrice.Text != "" &&

                        textBoxDesc.Text != "" &&
                        comboBoxBrand.Text != "" &&
                        comboBoxCategory.Text != "")
                {
                    string sql = "INSERT INTO Product(PCode,Barcode,PDesc,BrandId,CategoryId,Price,Qty) VALUES (@PCode,@Barcode,@PDesc,@BrandId,@CategoryId,@Price,@Qty) ";
                    this.AddUpdateDelete(sql, "Add");
                }
                else MessageBox.Show("Please complete details.");

            }


        }


        private string GetBrandID()
        {
            SqlCommand comBID = new SqlCommand("Select Id from Brand where Name like '" + comboBoxBrand.SelectedItem.ToString() + "'", cn);
            dr = comBID.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                BID = dr[0].ToString();
            }
            dr.Close();
            return BID;
        }

        private string GetCategoryID()
        {
            SqlCommand comCID = new SqlCommand("Select Id from Category where Name like '" + comboBoxCategory.SelectedItem.ToString() + "'", cn);
            dr = comCID.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                CID = dr[0].ToString();
            }
            dr.Close();

            return CID;
        }

        private List<string> GetProductCodeItems()
        {

            SqlCommand comPCode = new SqlCommand("SELECT PCode from Product", cn);
            PCodeList = new List<string>();
            dr = comPCode.ExecuteReader();

            while (dr.Read())
            {
                PCodeList.Add(dr[0].ToString());
            }

            dr.Close();

            return PCodeList;

        }


        private void buttonUpdateProduct_Click(object sender, RoutedEventArgs e)
        {

            string sql = "UPDATE Product SET PCode = @PCode, PDesc = @PDesc, BrandId = @BrandId, CategoryId = @CategoryId, Price = @Price, Qty = @Qty WHERE PCode = @PCode";
            this.AddUpdateDelete(sql, "Update");
            this.InitializedButtonState();
        }



        private void buttonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            string sql = "DELETE FROM Product WHERE PCode = @PCode ";
            this.AddUpdateDelete(sql, "Delete");
            this.InitializedButtonState();

        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            this.Clear();

        }

        private void InitializedButtonState()
        {

            buttonAddProduct.IsEnabled = true;
            buttonUpdateProduct.IsEnabled = false;
            buttonDeleteProduct.IsEnabled = false;

        }

        private void LoadCategory()
        {


            //comboBoxCategory.Items.Clear();
            SqlCommand com = new SqlCommand("select distinct Name  from Category", cn);

            dr = com.ExecuteReader();

            while (dr.Read())
            {
                comboBoxCategory.Items.Add(dr[0].ToString());
            }

            dr.Close();




        }

        private void LoadBrand()
        {


            //  comboBoxBrand.Items.Clear();
            SqlCommand com = new SqlCommand("select distinct Name  from Brand", cn);

            dr = com.ExecuteReader();

            while (dr.Read())
            {
                comboBoxBrand.Items.Add(dr[0].ToString());
            }

            dr.Close();


        }



        private void Clear()
        {

            textBoxProductCode.Text = "";
            //textBoxBarCode.Text = "";
            textBoxPrice.Text = "";
            //textBoxQty.Text = "";
            textBoxDesc.Text = "";
            comboBoxBrand.Text = null;
            comboBoxCategory.Text = null;
            textBoxProductCode.IsEnabled = true;
            this.InitializedButtonState();
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
    }
}

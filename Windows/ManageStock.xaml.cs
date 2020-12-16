using POS_and_Inventory_Management_System.Classes;
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
    /// Interaction logic for ManageStock.xaml
    /// </summary>
    public partial class ManageStock : Window
    {
        DBConnection dbCon = new DBConnection();
        SqlConnection cn;
        DataTable dt = new DataTable();
        DataView dv;


        List<TempStockInProducts> tempStocks = new List<TempStockInProducts>();
        List<StockInProducts> stocks = new List<StockInProducts>();


        public ManageStock()
        {
            InitializeComponent();
            datePickerDateIssued.SelectedDate = DateTime.Now;

            dv = new DataView(dt);


            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            cn = new SqlConnection(dbCon.Connection());


            cn.Open();



            // datePickerDateIssued.SelectedDate.Value.Hour = DateTime.Now;


        }


        private void UpdateGridProducts()
        {
            dataGridProduct.ItemsSource = null;
            dt.Clear();

            SqlCommand com = cn.CreateCommand();
            com.CommandText = "SELECT * FROM Product";
            com.CommandType = CommandType.Text;

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {

                stocks.Add(new StockInProducts
                {
                    PCode = read[0].ToString(),
                    Barcode = read[1].ToString(),
                    PDesc = read[2].ToString(),
                    BrandID = Int32.Parse(read[3].ToString()),
                    CategoryID = Int32.Parse(read[4].ToString()),
                    Price = Double.Parse(read[5].ToString()),
                    Qty = Int32.Parse(read[6].ToString())
                });


            }

            dt.Columns.Add("PCode");
            dt.Columns.Add("PDesc");
            dt.Columns.Add("Qty");


            foreach (StockInProducts s in stocks)
            {

                dt.Rows.Add(s.PCode, s.PDesc, s.Qty);

            }


            dv = new DataView(dt);
            dataGridProduct.ItemsSource = dv;
        }

        private void UpdateGridTemporaryProducts()
        {
            dataGridTemporaryProduct.Items.Clear();

            dataGridTemporaryProduct.ItemsSource = tempStocks;


        }

        private void Clear()
        {
            textBoxQty.Text = "";
            textBoxRefCode.Text = "";
            textBoxStockInBy.Text = "";
            datePickerDateIssued.SelectedDate = DateTime.Today;
        }



        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.UpdateGridProducts();
            this.UpdateGridTemporaryProducts();

        }

        private void dataGridProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            DataGrid dg = sender as DataGrid;
            DataRowView row = dg.SelectedItem as DataRowView;



            if (textBoxRefCode.Text != "")
            {
                if (textBoxQty.Text != "")
                {
                    if (textBoxStockInBy.Text != "")
                    {
                        for (int i = 0; i < stocks.Count; i++)
                        {
                            if (dg.SelectedIndex == i)
                            {

                                tempStocks.Add(new TempStockInProducts
                                {
                                    TPCode = stocks[i].PCode,
                                    TPDesc = stocks[i].PDesc,
                                    TPrice = stocks[i].Price,
                                    TBarcode = stocks[i].Barcode,
                                    TQty = Int32.Parse(textBoxQty.Text),
                                    TBrandId = stocks[i].BrandID,
                                    TCategoryId = stocks[i].CategoryID,
                                    TRefCode = textBoxRefCode.Text,
                                    TDate = datePickerDateIssued.SelectedDate.Value.Date.ToShortDateString(),
                                    TStockInBy = textBoxStockInBy.Text

                                });

                                this.Clear();
                                dataGridTemporaryProduct.Items.Refresh();
                            }
                        }
                    }
                    else
                    {
                        textBoxStockInBy.Focus();
                        MessageBox.Show("Please input stock in by.");
                    }
                }
                else
                {
                    textBoxQty.Focus();
                    MessageBox.Show("Please input a quantity.");
                }
            }
            else
            {
                textBoxRefCode.Focus();
                MessageBox.Show("Please input a reference number.");

            }


        }

        private void dataGridTemporaryProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = sender as DataGrid;

            tempStocks.RemoveAt(dg.SelectedIndex);
            dataGridTemporaryProduct.Items.Refresh();

        }

        private void ClearTempProducts()
        {

            tempStocks.Clear();

            dataGridTemporaryProduct.Items.Refresh();


        }

        private void ClearStockProducts()
        {
            stocks.Clear();
            dt.Columns.Remove("PCode");
            dt.Columns.Remove("PDesc");
            dt.Columns.Remove("Qty");
            dataGridProduct.Items.Refresh();

        }



        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            this.ClearTempProducts();
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {

            if (tempStocks.Count > 0)
            {


                string sql = "Insert INTO StockIn(RefCode,PCode,StockInBy,Date,Qty) Values (@TRefCode ,@TPCode,@TStockInBy,@TDateIssued,@TQty) ; " +
                             "UPDATE Product SET Qty = Qty + @TQty WHERE PCode = @TPCode ";

                this.InsertUpdateData(sql);
                this.ClearStockProducts();
                this.ClearTempProducts();
                this.UpdateGridProducts();


            }
            else MessageBox.Show("Please add items.");

        }

        private void InsertUpdateData(string sqlStatement)
        {


            SqlCommand com = cn.CreateCommand();
            com.CommandText = sqlStatement;
            com.CommandType = CommandType.Text;

            foreach (TempStockInProducts temp in tempStocks)
            {
                com.Parameters.AddWithValue("TRefCode", temp.TRefCode);
                com.Parameters.AddWithValue("TStockInBy", temp.TStockInBy);
                com.Parameters.AddWithValue("TDateIssued", DateTime.Parse(temp.TDate));
                com.Parameters.AddWithValue("TPCode", temp.TPCode);
                com.Parameters.AddWithValue("TQty", temp.TQty);
                com.ExecuteNonQuery();
                com.Parameters.Clear();
            }

            MessageBox.Show("Stocks inserted successfully.");


        }



        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            this.Clear();
        }

        private void textBoxSearchPCode_TextChanged(object sender, TextChangedEventArgs e)
        {

            dv.RowFilter = string.Format("PCode LIKE '%{0}%'", textBoxSearchPCode.Text);
            dataGridProduct.ItemsSource = dv;

        }

        private void textBoxSearchPName_TextChanged(object sender, TextChangedEventArgs e)
        {
            dv.RowFilter = string.Format("PDesc LIKE '%{0}%'", textBoxSearchPName.Text);
            dataGridProduct.ItemsSource = dv;
        }


    }
}

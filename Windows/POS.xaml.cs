using POS_and_Inventory_Management_System.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace POS_and_Inventory_Management_System.Windows
{
    /// <summary>
    /// Interaction logic for POS.xaml
    /// </summary>
    public partial class POS : Window
    {
        DBConnection dbCon = new DBConnection();
        SqlConnection cn;
        DataTable dt = new DataTable();
        DataView dv;

        List<StockInProducts> stocks = new List<StockInProducts>();
        List<Receipt> receipt = new List<Receipt>();


        List<CartItem> cartItems = new List<CartItem>();

        string letters = "qwertyuiopasdfghjklzxcvbnm";


        public POS()
        {

            InitializeComponent();
            datePickerDateIssued.SelectedDate = DateTime.Now;
            cn = new SqlConnection(dbCon.Connection());


            textBlockCashier.Text = App.loginName;

            this.ResetCheckout();





            cn.Open();

            //this.GetReceiptID();

            textBlockReceiptNo.Text = GetProductCodeItems().ToString();
            this.UpdateCartItems();



        }


        private void UpdateCartItems()
        {

            var totalAmount = 0d;

            dataGridCartItems.ItemsSource = null;
            dataGridCartItems.ItemsSource = cartItems;
            dataGridCartItems.Items.Refresh();



            foreach (CartItem c in cartItems)
            {

                totalAmount += c.CI_Price;

            }

            textBoxAmount.Text = totalAmount.ToString();

        }


        private void UpdateGridProducts()
        {

            dataGridLoadProducts.ItemsSource = null;
            stocks.Clear();


            SqlCommand com = cn.CreateCommand();
            com.CommandText = "SELECT * From Product";

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

            read.Close();



            dt.Clear();

            dt.Columns.Add("PCode");

            dt.Columns.Add("PDesc");
            dt.Columns.Add("Price");
            dt.Columns.Add("Qty");



            foreach (StockInProducts s in stocks)
            {

                dt.Rows.Add(s.PCode, s.PDesc, s.Price, s.Qty);

            }

            dv = new DataView(dt);
            dataGridLoadProducts.ItemsSource = dv;
        }






        private void dataGridLoadProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            buttonAddToCart.IsEnabled = true;

            var dg = sender as DataGrid;

            DataRowView item = dg.SelectedItem as DataRowView;

            if (item != null)
            {
                textBlockPCode.Text = item.Row[0].ToString();

                textBlockItemName.Text = item.Row[1].ToString();
                textBoxPrice.Text = item.Row[2].ToString();
                textBoxQty.Text = "1";
                textBlockTotal.Text = item.Row[3].ToString();

            }





        }

        private void textBoxQtyPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxQty.Text != "" && textBoxPrice.Text != "")
            {

                double qty = Double.Parse(textBoxQty.Text);
                double price = Double.Parse(textBoxPrice.Text);
                var totalUpdate = qty * price;
                textBlockTotal.Text = totalUpdate.ToString();
            }
        }


        private int GetProductCodeItems()
        {

            SqlCommand comPCode = new SqlCommand("SELECT ReceiptId from Receipt", cn);
            var r = new List<int>();
            var dr = comPCode.ExecuteReader();

            while (dr.Read())
            {
                r.Add(Int32.Parse(dr[0].ToString()));
            }

            dr.Close();


            var rr = r.Last() + 1;

            return rr;

        }

        private void buttonAddToCart_Click(object sender, RoutedEventArgs e)
        {

            if (textBlockPCode.Text != "")
            {
                cartItems.Add(new CartItem
                {
                    //CI_Barcode = textBlockBarcode.Text,
                    CI_ItemName = textBlockItemName.Text,
                    CI_Price = Double.Parse(textBoxPrice.Text),
                    CI_Qty = Int32.Parse(textBoxQty.Text),
                    CI_ReceiptID = Int32.Parse(textBlockReceiptNo.Text),
                    CI_Total = Double.Parse(textBlockTotal.Text),
                    CI_PCode = textBlockPCode.Text
                });



                this.UpdateCartItems();
                this.Reset();
                this.GetDiscount();

            }
            else MessageBox.Show("Select an item please.");




        }

        private void ClearStockProducts()
        {
            stocks.Clear();
            dt.Columns.Remove("PCode");
            dt.Columns.Remove("PDesc");
            dt.Columns.Remove("Qty");

            dt.Columns.Remove("Price");
            dataGridLoadProducts.Items.Refresh();

        }


        private void Reset()
        {

            //textBlockBarcode.Text = "";
            textBlockItemName.Text = "";
            textBoxPrice.Text = "";
            textBoxQty.Text = "";
            textBlockPCode.Text = "";
            textBlockTotal.Text = "";



            buttonAddToCart.IsEnabled = false;



        }

        private void ResetCheckout()
        {
            textBoxDiscount.Text = 0.ToString();
            textBoxPayment.Text = 0.ToString();
            textBoxDiscountedPrice.Text = 0.ToString();
            textBoxChange.Text = 0.ToString();
            textBoxAmount.Text = 0.ToString();
        }

        private void dataGridCartItems_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = sender as DataGrid;

            cartItems.RemoveAt(dg.SelectedIndex);
            dataGridCartItems.Items.Refresh();
            UpdateCartItems();
            GetDiscount();
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void GetDiscount()
        {

            var percent = Double.Parse(textBoxDiscount.Text) * 0.01d;
            var originalAmount = Double.Parse(textBoxAmount.Text);
            var discountedPrice = percent * originalAmount;

            var totalUpdate = originalAmount - discountedPrice;



            textBoxDiscountedPrice.Text = totalUpdate.ToString();

        }

        private void textBoxDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxDiscount.Text != "")
            {
                if (!textBoxDiscount.Text.Contains(letters))
                {

                    try
                    {
                        this.GetDiscount();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Input numbers only.");
                    }
                }

            }
            else
            {
                textBoxDiscountedPrice.Text = 0.ToString();
                textBoxDiscount.Text = 0.ToString();
            }






        }

        private void textBoxPayment_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxPayment.Text != "")
            {

                if (!textBoxDiscount.Text.Contains(letters))
                {

                    try
                    {
                        var customerPayment = Double.Parse(textBoxPayment.Text);
                        var discountedAmount = Double.Parse(textBoxDiscountedPrice.Text);
                        var totalAmount = Double.Parse(textBoxAmount.Text);
                        var customerChange = 0d;


                        if (textBoxDiscount.Text == "") customerChange = customerPayment - totalAmount;
                        else customerChange = customerPayment - discountedAmount;



                        textBoxChange.Text = customerChange.ToString();

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Input numbers only.");
                    }
                }





            }
            else
            {
                textBoxChange.Text = 0.ToString();
                textBoxPayment.Text = 0.ToString();
            }

        }

        private void InsertUpdateData(string sqlStatement)
        {

            SqlCommand com = cn.CreateCommand();
            com.CommandText = sqlStatement;
            com.CommandType = CommandType.Text;

            foreach (CartItem cartItem in cartItems)
            {

                com.Parameters.AddWithValue("CQty", cartItem.CI_Qty);
                com.Parameters.AddWithValue("CBarcode", 0);
                com.Parameters.AddWithValue("CItemName", cartItem.CI_ItemName);
                com.Parameters.AddWithValue("CPrice", cartItem.CI_Price);
                com.Parameters.AddWithValue("CTotal", cartItem.CI_Total);
                com.Parameters.AddWithValue("CReceiptId", textBlockReceiptNo.Text);
                com.Parameters.AddWithValue("CPCode", cartItem.CI_PCode);




                com.ExecuteNonQuery();
                com.Parameters.Clear();

            }

            MessageBox.Show("Thank you for shopping!");


        }

        private void InsertReceipt(string sqlStatement)
        {

            SqlCommand com = cn.CreateCommand();
            com.CommandText = sqlStatement;
            com.CommandType = CommandType.Text;

            com.Parameters.AddWithValue("RReceiptId", textBlockReceiptNo.Text);
            com.Parameters.AddWithValue("RCashierName", textBlockCashier.Text);
            com.Parameters.AddWithValue("RDateIssued", DateTime.Parse(datePickerDateIssued.SelectedDate.Value.ToShortDateString()));
            com.Parameters.AddWithValue("RDiscount", Double.Parse(textBoxDiscount.Text));
            com.Parameters.AddWithValue("RDiscountedPrice", Double.Parse(textBoxDiscountedPrice.Text));
            com.Parameters.AddWithValue("RTotalAmount", Double.Parse(textBoxAmount.Text));
            com.Parameters.AddWithValue("RCustomerPayment", Double.Parse(textBoxPayment.Text));
            com.Parameters.AddWithValue("RCustomerChange", Double.Parse(textBoxChange.Text));

            com.ExecuteNonQuery();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.UpdateGridProducts();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            cn.Close();
        }

        private void ClearTempProducts()
        {

            cartItems.Clear();

            dataGridCartItems.Items.Refresh();


        }

        private void buttonCheckOut_Click(object sender, RoutedEventArgs e)
        {



            int payment = Int32.Parse(textBoxPayment.Text);
            double price = Double.Parse(textBoxDiscountedPrice.Text);

            if (payment >= price && payment != 0)
            {
                if (cartItems.Count > 0)
                {


                    string sql = "Insert INTO CartItem(Barcode,ItemName,Price,Qty,Total,ReceiptID) Values (@CBarcode ,@CItemName,@CPrice,@CQty,@CTotal,@CReceiptId); " +
                                 "UPDATE Product SET Qty = Qty - @CQty WHERE PCode = @CPCode ";

                    this.InsertReceipt("Insert INTO Receipt(ReceiptID,CashierName,DateIssued,Discount,DiscountedPrice,TotalAmount) Values (@RReceiptId,@RCashierName,@RDateIssued,@RDiscount,@RDiscountedPrice,@RTotalAmount); ");
                    this.InsertUpdateData(sql);
                    this.ClearTempProducts();
                    this.ClearStockProducts();
                    this.UpdateGridProducts();

                    ResetCheckout();


                    textBlockReceiptNo.Text = this.GetProductCodeItems().ToString();
                }
                else MessageBox.Show("Please add something in the cart.");
            }
            else MessageBox.Show("Please add a valid amount for payment.");





        }




        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            this.ClearTempProducts();
        }



        private void textBoxSearchItem_TextChanged(object sender, TextChangedEventArgs e)
        {
            dv.RowFilter = string.Format("PCode LIKE '%{0}%'", textBoxSearchItem.Text);
            dataGridLoadProducts.ItemsSource = dv;
        }
    }
}

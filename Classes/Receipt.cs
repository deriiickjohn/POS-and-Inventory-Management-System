namespace POS_and_Inventory_Management_System.Classes
{
    class Receipt
    {

        public int R_ReceiptID { get; set; }
        public string R_CashierName { get; set; }

        public string R_DateIssued { get; set; }
        public double R_Discount { get; set; }

        public double R_DiscountedPrice { get; set; }

        public double R_TotalAmount { get; set; }

        public double R_CustomerPayment { get; set; }

        public double R_CustomerChange { get; set; }
    }
}

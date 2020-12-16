namespace POS_and_Inventory_Management_System.Classes
{
    class CartItem
    {

        public int CI_ReceiptID { get; set; }
        public string CI_Barcode { get; set; }
        public string CI_ItemName { get; set; }
        public double CI_Price { get; set; }
        public int CI_Qty { get; set; }

        public string CI_PCode { get; set; }
        public double CI_Total { get; set; }


    }
}

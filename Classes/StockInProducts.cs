namespace POS_and_Inventory_Management_System.Classes
{
    class StockInProducts
    {
        public string PCode { get; set; }
        public string Barcode { get; set; }

        public string PDesc { get; set; }

        public int BrandID { get; set; }

        public int CategoryID { get; set; }

        public double Price { get; set; }

        public int Qty { get; set; }
    }
}

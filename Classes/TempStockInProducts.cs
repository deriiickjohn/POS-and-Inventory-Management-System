using System;

namespace POS_and_Inventory_Management_System.Classes
{
    class TempStockInProducts
    {

        public string TPCode { get; set; }
        public string TBarcode { get; set; }

        public string TPDesc { get; set; }

        public int TBrandId { get; set; }

        public int TCategoryId { get; set; }

        public double TPrice { get; set; }

        public int TQty { get; set; }

        public string TRefCode { get; set; }

        public string TStockInBy { get; set; }

        public String TDate { get; set; }
    }
}

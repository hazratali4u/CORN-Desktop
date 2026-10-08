using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CORNPointOfSale
{
    public class ClassSession
    {

        // data tables used in Voucher Entry
        public static DataTable dtHead { get; set; }
        public static DataTable dtVoucher { get; set; }
        public static DataTable dtSKUdata { get; set; }
        public static DataTable dtSKUdata2 { get; set; }
        // Data Table General   (Starting from Stock Register)
        public static DataTable dtPurchaseSKU { get; set; }
        public static DataTable Dtsku_Price { get; set; }
        public static DataTable DtSkusDetail { get; set; }

    }
}

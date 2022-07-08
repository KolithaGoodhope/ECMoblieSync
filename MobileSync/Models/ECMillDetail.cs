using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSync.Models
{
    public class ECMillDetail
    {
        public int MILL_ID { get; set; }
        public string MILL_CODE { get; set; }
        public string MILL_NAME { get; set; }
        public int MILL_CROP_QTY { get; set; }
        public double MILL_CROP_RATE { get; set; }
        public double MILL_CROP_PENALTY_PERCENTAGE { get; set; }
        public double MILL_CROP_PENALTY_COST { get; set; }
        public int COMPANY_ID { get; set; }
        public int SUPPLIER_ID { get; set; }
        public string SUPPLIER_NAME { get; set; }
    }
}
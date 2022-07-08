using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSync.Models
{
    public class ECDetail
    {
        public int LOCATION_ID { get; set; }
        public String LOCATION_CODE { get; set; }
        public String LOCATION_NAME { get; set; }
        public double LOCATION_CROP_QTY { get; set; }
        public double LOCATION_CROP_RATE { get; set; }
        public double LOCATION_CROP_PENALTY_PERCENTAGE { get; set; }
        public double LOCATION_CROP_PENALTY_COST { get; set; }
        public int COMPANY_ID { get; set; }
        public int SUPPLIER_ID { get; set; }
    }
}
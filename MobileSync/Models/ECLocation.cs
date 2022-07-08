using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSync.Models
{
    public class ECLocation
    {
        public int LOCATION_ID { get; set; }
        public string LOCATION_CODE { get; set; }
        public string LOCATION_NAME { get; set; }
        public int LOCATION_CROP_QTY { get; set; }
        public double LOCATION_CROP_RATE { get; set; }
        public double LOCATION_CROP_PENALTY_PERCENTAGE { get; set; }
        public double LOCATION_CROP_PENALTY_COST { get; set; }        
    }
}
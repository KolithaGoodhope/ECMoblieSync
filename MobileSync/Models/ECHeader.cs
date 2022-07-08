using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSync.Models
{
    public class ECHeader
    {
        public int ECH_ID { get; set; }
        public String ECH_PURCHASED_ID { get; set; }
        public double ECH_INCENTIVE_PER_MT { get; set; }
        public int ECH_TOTAL_PURCHASED_QTY { get; set; }
        public double ECH_INCENTIVE { get; set; }
        public double ECH_EXTERNAL_CROP_COST { get; set; }
        public double ECH_COST_AVG_PER_MT { get; set; }
        public double ECH_TOTAL_PENALTY_COST { get; set; }
        public double ECH_COST_AFTER_PENALTY { get; set; }
        public int ECH_CONFIRMED { get; set; }
        public DateTime ECH_PURCHASE_DATE { get; set; }
        public List<ECMillDetail> ECH_ECMILL_DETAIL_LIST { get; set; }
    }
}
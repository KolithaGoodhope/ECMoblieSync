using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSync.Models
{
    public class NFCVehicleDetail
    {
        public int USER_ID { get; set; }
        public int ENTITY_ID { get; set; }
        public int VEHICLE_ID { get; set; }
        public String DATE { get; set; }
        public int EC_NFC_IS_TEMP_VEHICLE { get; set; }
    }
}
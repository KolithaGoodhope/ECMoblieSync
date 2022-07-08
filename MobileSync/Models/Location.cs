using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSync.Models
{

    public class Location
    {
        public int LOC_ID { get; set; }
        public string LOC_CODE { get; set; }
        public string LOC_LOCATION_NAME { get; set; }
        public string LOC_DESCRIPTION { get; set; }
    }
}
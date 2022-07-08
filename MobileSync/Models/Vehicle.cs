using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSync.Models
{
    public class Vehicle
    {
        public int ECM_VEH_VEHICLE_ID { get; set; }
        public string ECM_VEH_VEHICLE_DESCRIPTION { get; set; }
        public string ECM_VEH_ALIAS { get; set; }
        public int ECM_VEH_VEHICLE_REF_ID { get; set; }
    }
}
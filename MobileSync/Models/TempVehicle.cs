using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSync.Models
{
    public class TempVehicle
    {
        public int ECM_TEMP_VEH_LIST_VEHICLE_ID { get; set; }
        public string ECM_TEMP_VEH_LIST_VEHICLE_DESCRIPTION { get; set; }
        public string ECM_TEMP_VEH_LIST_ALIAS { get; set; }
        public int ECM_TEMP_VEH_LIST_IS_ASSIGNED { get; set; }
    }
}
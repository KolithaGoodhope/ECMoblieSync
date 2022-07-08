using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSync.Models
{
    public class Login
    {
        public int USR_ID { get; set; }
        public string USR_FIRST_NAME { get; set; }
        public string USR_LAST_NAME { get; set; }
        public string USR_USER_NAME { get; set; }
        public string USR_PASSWORD { get; set; }
        public int USR_LOCATION { get; set; }
        public int USR_ACTIVE { get; set; }
        public int USER_ROLE_ID { get; set; }
    }
}
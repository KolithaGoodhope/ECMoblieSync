using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSync.Models
{
    public class Entity
    {
        public int ECM_ENTITY_ID { get; set; }
        public string ECM_ENTITY_DESCRIPTION { get; set; }
        public string ECM_ALIAS { get; set; }
        public int ECM_ENTITY_REF_ID { get; set; }
        public int ECM_ENTITY_REF_PARENT_ID { get; set; }
        public int ECM_ENTITY_TYPE { get; set; }
    }
}
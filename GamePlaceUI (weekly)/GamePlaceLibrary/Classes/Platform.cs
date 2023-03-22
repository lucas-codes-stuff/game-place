using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlaceUI
{
    public class Platform
    {
        public int PLAT_ID { get; set; }
        public string PLAT_NAME { get; set; }
        public string PLAT_DESC { get; set; }

        public Platform(int id, string description, string name)
        {
            PLAT_ID = id;
            PLAT_DESC = description;
            PLAT_NAME = name;
        }

        public override string ToString() => $"{PLAT_ID}-{PLAT_NAME} - " +
            $"Description : {PLAT_DESC}";
    }
}

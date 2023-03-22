using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlaceUI
{
    public class Category
    {
        public int CAT_ID { get; set; }
        public string CAT_NAME { get; set; }
        public string CAT_DESC { get; set; }

        public Category(int id, string description, string name)
        {
            CAT_ID = id;
            CAT_DESC = description;
            CAT_NAME = name;
        }

        public override string ToString() => $"{CAT_ID}-{CAT_NAME} - " +
            $"Description : {CAT_DESC}";
    }
}

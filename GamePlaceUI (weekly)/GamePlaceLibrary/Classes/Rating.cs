using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlaceUI
{
    public class Rating
    {
        public int RATING_ID { get; set; }
        public string RATING_NAME { get; set; }
        public string RATING_DESC { get; set; }

        public Rating(int id, string description, string name)
        {
            RATING_ID = id;
            RATING_DESC = description;
            RATING_NAME = name;
        }

        public override string ToString() => $"{RATING_ID}-{RATING_NAME} - " +
            $"Description : {RATING_DESC}";
    }
}

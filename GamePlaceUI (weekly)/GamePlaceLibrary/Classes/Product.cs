using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlaceUI
{
    public class Product
    {
        public int PROD_ID  { get; set; }
        public string PROD_NM { get; set; }
        public int PROD_PLAT_CD { get; set; }
        public string PROD_PUB { get; set; }
        public string PROD_DEV { get; set; }
        public int PROD_CAT_CD { get; set; }
        public float PROD_PRICE { get; set; }
        public int PROD_RATING_CD { get; set; }
        public string PROD_DESCR { get; set; }
        public string PROD_IMAGE { get; set; }
        public string PROD_ADD_DTM { get; set; }
        public string PROD_CHG_DTM { get; set; }
        public string PROD_STAT_CD { get; set; }


        public Product(
            int id,
            string name, string publisher,
            string developer, float price, int platform, int rating,
            int category, string description,
            string added, string changed, string status, string image)
        {
            PROD_ID = id;
            PROD_NM = name;
            PROD_PUB = publisher;
            PROD_DEV = developer;
            PROD_PRICE = price;
            PROD_PLAT_CD = platform;
            PROD_RATING_CD = rating;
            PROD_CAT_CD = category;
            PROD_DESCR = description;
            PROD_ADD_DTM = added;
            PROD_CHG_DTM = changed;
            PROD_STAT_CD = status;
            PROD_IMAGE = image;
        }

        public Product()
        {

        }

        public override string ToString() =>
            $"{PROD_ID}: {PROD_NM} Publisher: {PROD_PUB} - Developer: {PROD_DEV} - " +
            $"Description: {PROD_DESCR} - Price: {PROD_PRICE}";
    }
}

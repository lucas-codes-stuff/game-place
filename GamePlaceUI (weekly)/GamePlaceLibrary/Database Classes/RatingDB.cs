using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;

namespace GamePlaceUI
{
    public class RatingDB
    {
        public static Rating[] Inquire()
        {
            LinkedList<Rating> ratings = new LinkedList<Rating>();

            int RATING_ID = 0;
            string RATING_DESC = string.Empty;
            string RATING_NAME = string.Empty;

            string strSQL = "SELECT RATING_ID, RATING_DESC, RATING_NAME FROM RATING_LKP";

            OleDbConnection cn = new OleDbConnection(ProductDB.strConnString);
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbDataReader dr = null;

            cn.Open();
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                RATING_ID = Convert.ToInt32(dr["RATING_ID"]);
                RATING_DESC = dr["RATING_DESC"].ToString();
                RATING_NAME = dr["RATING_NAME"].ToString();

                ratings.AddLast(new Rating(RATING_ID, RATING_DESC, RATING_NAME));
            }

            return ratings.ToArray<Rating>();
        }
    }
}

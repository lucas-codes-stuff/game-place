using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;

namespace GamePlaceUI
{
    public class CategoryDB
    {
        public static Category[] Inquire()
        {
            LinkedList<Category> categories = new LinkedList<Category>();

            int CAT_ID = 0;
            string CAT_DESC = string.Empty;
            string CAT_NAME = string.Empty;

            string strSQL = "SELECT CAT_ID, CAT_DESC, CAT_NAME FROM CATEGORY_LKP";

            OleDbConnection cn = new OleDbConnection(ProductDB.strConnString);
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbDataReader dr = null;

            cn.Open();
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                CAT_ID = Convert.ToInt32(dr["CAT_ID"]);
                CAT_DESC = dr["CAT_DESC"].ToString();
                CAT_NAME = dr["CAT_NAME"].ToString();

                categories.AddLast(new Category(CAT_ID, CAT_DESC, CAT_NAME));
            }

            return categories.ToArray<Category>();
        }
    }
}

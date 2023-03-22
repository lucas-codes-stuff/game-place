using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;

namespace GamePlaceUI
{
    public class PlatformDB
    {
        public static Platform[] Inquire()
        {
            LinkedList<Platform> platforms = new LinkedList<Platform>();

            int PLAT_ID = 0;
            string PLAT_DESC = string.Empty;
            string PLAT_NAME = string.Empty;

            string strSQL = "SELECT PLAT_ID, PLAT_DESC, PLAT_NAME FROM PLATFORM_LKP";

            OleDbConnection cn = new OleDbConnection(ProductDB.strConnString);
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbDataReader dr = null;

            cn.Open();
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                PLAT_ID = Convert.ToInt32(dr["PLAT_ID"]);
                PLAT_DESC = dr["PLAT_DESC"].ToString();
                PLAT_NAME = dr["PLAT_NAME"].ToString();

                platforms.AddLast(new Platform(PLAT_ID, PLAT_DESC, PLAT_NAME));
            }

            return platforms.ToArray<Platform>();
        }
    }
}

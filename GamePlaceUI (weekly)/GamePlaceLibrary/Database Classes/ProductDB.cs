using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;

namespace GamePlaceUI
{
    public class ProductDB
    {
           public static string strConnString =
              @"Provider=Microsoft.ACE.OLEDB.12.0;
                Persist Security Info=False;
                Data Source=.\Data\GamePlace.accdb;";

        public static Product[] Inquire()
        {
            LinkedList<Product> products = new LinkedList<Product>();

            Product p = null;

            String strSQL = "SELECT PROD_ID, " +
                                "PROD_NM, " +
                                "PROD_PLAT_CD, " +
                                "PROD_PUB, " +
                                "PROD_DEV, " +
                                "PROD_CAT_CD, " +
                                "PROD_PRICE, " +
                                "PROD_RATING_CD, " +
                                "PROD_DESCR, " +
                                "PROD_IMAGE, " +
                                "PROD_ADD_DTM, " +
                                "PROD_CHG_DTM, " +
                                "PROD_STAT_CD, " +
                                "PROD_IMAGE" +
                                " FROM PRODUCTS_MSTR;";

            OleDbConnection cn = new OleDbConnection(ProductDB.strConnString);
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbDataReader dr = null;

            cn.Open();
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                int id = int.Parse(dr["PROD_ID"].ToString());
                string name = dr["PROD_NM"].ToString();
                int platform = int.Parse(dr["PROD_PLAT_CD"].ToString());
                string publisher = dr["PROD_PUB"].ToString();
                string developer = dr["PROD_DEV"].ToString();
                int category = int.Parse(dr["PROD_CAT_CD"].ToString());
                float price = float.Parse(dr["PROD_PRICE"].ToString());
                int rating = int.Parse(dr["PROD_RATING_CD"].ToString());
                string description = dr["PROD_DESCR"].ToString();
                string added = dr["PROD_ADD_DTM"].ToString();
                string changed = dr["PROD_CHG_DTM"].ToString();
                string status = dr["PROD_STAT_CD"].ToString();
                string image = dr["PROD_IMAGE"].ToString();

                p = new Product(id,
                    name, publisher,
                    developer, price, platform, rating,
                    category, description,
                    added, changed, status, image);

                products.AddLast(p);
            }

            return products.ToArray<Product>();
        }
        public static int Add(Product p)
        {
            int newID = -1;

            string strSQL = "INSERT INTO PRODUCTS_MSTR (" +
                                "PROD_NM," +
                                "PROD_PLAT_CD," +
                                "PROD_PUB," +
                                "PROD_DEV," +
                                "PROD_CAT_CD," +
                                "PROD_PRICE," +
                                "PROD_RATING_CD," +
                                "PROD_DESCR," +
                                "PROD_ADD_DTM," +
                                "PROD_CHG_DTM," +
                                "PROD_STAT_CD," +
                                "PROD_IMAGE" +
                                ") VALUES (" +
                                "@PROD_NM," +
                                "@PROD_PLAT_CD," +
                                "@PROD_PUB," +
                                "@PROD_DEV," +
                                "@PROD_CAT_CD," +
                                "@PROD_PRICE," +
                                "@PROD_RATING_CD," +
                                "@PROD_DESCR," +
                                "@PROD_ADD_DTM," +
                                "@PROD_CHG_DTM," +
                                "@PROD_STAT_CD," +
                                "@PROD_IMAGE);";

            OleDbConnection cn = new OleDbConnection(strConnString);
            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("@PROD_NM", OleDbType.Char, 50);
            pm.Direction = ParameterDirection.Input;
            pm.Value = p.PROD_NM;
            cm.Parameters.Add(pm);

            pm = new OleDbParameter("@PROD_PLAT_CD", OleDbType.Integer);
            pm.Direction = ParameterDirection.Input;
            pm.Value = p.PROD_PLAT_CD;
            cm.Parameters.Add(pm);

            pm = new OleDbParameter("@PROD_PUB", OleDbType.Char, 50);
            pm.Direction = ParameterDirection.Input;
            pm.Value = p.PROD_PUB;
            cm.Parameters.Add(pm);

            pm = new OleDbParameter("@PROD_DEV", OleDbType.Char, 50);
            pm.Direction = ParameterDirection.Input;
            pm.Value = p.PROD_DEV;
            cm.Parameters.Add(pm);

            pm = new OleDbParameter("@PROD_CAT_CD", OleDbType.Integer);
            pm.Direction = ParameterDirection.Input;
            pm.Value = p.PROD_CAT_CD;
            cm.Parameters.Add(pm);

            pm = new OleDbParameter("@PROD_PRICE", OleDbType.Single);
            pm.Direction = ParameterDirection.Input;
            pm.Value = p.PROD_PRICE;
            cm.Parameters.Add(pm);

            pm = new OleDbParameter("@PROD_RATING_CD", OleDbType.Integer);
            pm.Direction = ParameterDirection.Input;
            pm.Value = p.PROD_RATING_CD;
            cm.Parameters.Add(pm);

            pm = new OleDbParameter("@PROD_DESCR", OleDbType.LongVarChar, 200);
            pm.Direction = ParameterDirection.Input;
            pm.Value = p.PROD_DESCR;
            cm.Parameters.Add(pm);

            pm = new OleDbParameter("@PROD_ADD_DTM", OleDbType.Char, 25);
            pm.Direction = ParameterDirection.Input;
            pm.Value = p.PROD_ADD_DTM;
            cm.Parameters.Add(pm);

            pm = new OleDbParameter("@PROD_CHG_DTM", OleDbType.Char, 25);
            pm.Direction = ParameterDirection.Input;
            pm.Value = p.PROD_CHG_DTM;
            cm.Parameters.Add(pm);

            pm = new OleDbParameter("@PROD_STAT_CD", OleDbType.Char, 100);
            pm.Direction = ParameterDirection.Input;
            pm.Value = p.PROD_STAT_CD;
            cm.Parameters.Add(pm);

            pm = new OleDbParameter("@PROD_IMAGE", OleDbType.Char, 100);
            pm.Direction = ParameterDirection.Input;
            pm.Value = p.PROD_IMAGE;
            cm.Parameters.Add(pm);

            cn.Open();
            newID = cm.ExecuteNonQuery();

            cm = new OleDbCommand("SELECT @@IDENTITY AS PROD_ID;", cn);
            newID = int.Parse(cm.ExecuteScalar().ToString());

            cn.Close();

            return newID;
        }
        public static int Delete(long PROD_ID)
        {
            int rc = -1;

            string strSQL = "UPDATE PRODUCTS_MSTR SET " +
                                "PROD_STAT_CD = 'D'," +
                                "PROD_CHG_DTM = Now()" +
                                " WHERE PROD_ID = @PROD_ID" +
                                " AND PROD_STAT_CD <> 'D';";

            OleDbConnection cn = new OleDbConnection(strConnString);
            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("@PROD_ID", OleDbType.Integer);
            pm.Direction = ParameterDirection.Input;
            pm.Value = PROD_ID;
            cm.Parameters.Add(pm);

            cn.Open();
            rc = cm.ExecuteNonQuery();
            cn.Close();

            return rc;
        }
        public static int Undelete(long PROD_ID)
        {
            int rc = -1;

            string strSQL = "UPDATE PRODUCTS_MSTR SET " +
                                "PROD_STAT_CD = 'A'," +
                                "PROD_CHG_DTM = Now()" +
                                " WHERE PROD_ID = @PROD_ID" +
                                " AND PROD_STAT_CD <> 'A';";

            OleDbConnection cn = new OleDbConnection(strConnString);
            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("@PROD_ID", OleDbType.Integer);
            pm.Direction = ParameterDirection.Input;
            pm.Value = PROD_ID;
            cm.Parameters.Add(pm);

            cn.Open();
            rc = cm.ExecuteNonQuery();
            cn.Close();

            return rc;
        }
        public static int Purge(long PROD_ID)
        {
            int rc = -1;

            string strSQL = "DELETE FROM PRODUCTS_MSTR" +
                                " WHERE PROD_ID = @PROD_ID" +
                                " AND PROD_STAT_CD = 'D';";

            OleDbConnection cn = new OleDbConnection(strConnString);
            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("@PROD_ID", OleDbType.Integer);
            pm.Direction = ParameterDirection.Input;
            pm.Value = PROD_ID;
            cm.Parameters.Add(pm);

            cn.Open();
            rc = cm.ExecuteNonQuery();
            cn.Close();

            return rc;
        }
        public static int Update(Product p)
        {
            int rc = -1;
            try
            {
                string strSQL = "UPDATE PRODUCTS_MSTR SET " +
                                                "PROD_NM = @PROD_NM," +
                                                "PROD_PLAT_CD = @PROD_PLAT_CD, " +
                                                "PROD_PUB = @PROD_PUB," +
                                                "PROD_DEV = @PROD_DEV, " +
                                                "PROD_CAT_CD = @PROD_CAT_CD," +
                                                "PROD_PRICE = @PROD_PRICE," +
                                                "PROD_RATING_CD = @PROD_RATING_CD," +
                                                "PROD_DESCR = @PROD_DESCR," +
                                                "PROD_IMAGE = @PROD_IMAGE," +
                                                "PROD_CHG_DTM = @PROD_CHG_DTM," +
                                                "PROD_STAT_CD = @PROD_STAT_CD" +
                                                " WHERE PROD_ID = @PROD_ID;";

                OleDbConnection cn = new OleDbConnection(strConnString);
                OleDbCommand cm = new OleDbCommand(strSQL, cn);



                OleDbParameter pm = new OleDbParameter("@PROD_NM", OleDbType.Char, 25);
                pm.Direction = ParameterDirection.Input;
                pm.Value = p.PROD_NM;
                cm.Parameters.Add(pm);

                pm = new OleDbParameter("@PROD_PLAT_CD", OleDbType.Integer);
                pm.Direction = ParameterDirection.Input;
                pm.Value = p.PROD_PLAT_CD;
                cm.Parameters.Add(pm);

                pm = new OleDbParameter("@PROD_PUB", OleDbType.Char, 50);
                pm.Direction = ParameterDirection.Input;
                pm.Value = p.PROD_PUB;
                cm.Parameters.Add(pm);

                pm = new OleDbParameter("@PROD_DEV", OleDbType.Char, 50);
                pm.Direction = ParameterDirection.Input;
                pm.Value = p.PROD_DEV;
                cm.Parameters.Add(pm);

                pm = new OleDbParameter("@PROD_CAT_CD", OleDbType.Integer);
                pm.Direction = ParameterDirection.Input;
                pm.Value = p.PROD_CAT_CD;
                cm.Parameters.Add(pm);

                pm = new OleDbParameter("@PROD_PRICE", OleDbType.Single);
                pm.Direction = ParameterDirection.Input;
                pm.Value = p.PROD_PRICE;
                cm.Parameters.Add(pm);

                pm = new OleDbParameter("@PROD_RATING_CD", OleDbType.Integer);
                pm.Direction = ParameterDirection.Input;
                pm.Value = p.PROD_RATING_CD;
                cm.Parameters.Add(pm);

                pm = new OleDbParameter("@PROD_DESCR", OleDbType.Char, 100);
                pm.Direction = ParameterDirection.Input;
                pm.Value = p.PROD_DESCR;
                cm.Parameters.Add(pm);

                pm = new OleDbParameter("@PROD_IMAGE", OleDbType.Char, 100);
                pm.Direction = ParameterDirection.Input;
                pm.Value = p.PROD_IMAGE;
                cm.Parameters.Add(pm);

                pm = new OleDbParameter("@PROD_CHG_DTM", OleDbType.Char, 25);
                pm.Direction = ParameterDirection.Input;
                pm.Value = DateTime.Now.ToString();
                cm.Parameters.Add(pm);

                pm = new OleDbParameter("@PROD_STAT_CD", OleDbType.Char, 100);
                pm.Direction = ParameterDirection.Input;
                pm.Value = p.PROD_STAT_CD;
                cm.Parameters.Add(pm);

                pm = new OleDbParameter("@PROD_ID", OleDbType.Integer);
                pm.Direction = ParameterDirection.Input;
                pm.Value = p.PROD_ID;
                cm.Parameters.Add(pm);

                cn.Open();
                rc = cm.ExecuteNonQuery();
                cn.Close();
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
            return rc;
        }
        public static Product[] ListProduct(string PROD_NM)
        {
            LinkedList<Product> productList = new LinkedList<Product>();

            Product p = null;

            string strSQL = "SELECT PROD_ID, " +
                                            "PROD_NM, " +
                                                "PROD_PLAT_CD, " +
                                                "PROD_PUB, " +
                                                "PROD_DEV, " +
                                                "PROD_CAT_CD, " +
                                                "PROD_PRICE, " +
                                                "PROD_RATING_CD, " +
                                                "PROD_DESCR, " +
                                                "PROD_IMAGE, " +
                                                "PROD_ADD_DTM, " +
                                                "PROD_CHG_DTM, " +
                                                "PROD_STAT_CD" +
                                                " FROM PRODUCTS_MSTR" +
                                                " WHERE PROD_NM LIKE @PROD_NM;";

            OleDbConnection cn = new OleDbConnection(strConnString);
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbDataReader dr = null;

            OleDbParameter pm = new OleDbParameter("@PROD_NM", OleDbType.VarChar, 75);
            pm.Direction = ParameterDirection.Input;
            pm.Value = PROD_NM + "%";
            cm.Parameters.Add(pm);

            cn.Open();
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                p = new Product();

                p.PROD_ID = int.Parse(dr["PROD_ID"].ToString());
                p.PROD_NM = dr["PROD_NM"].ToString();
                p.PROD_PLAT_CD = int.Parse(dr["PROD_PLAT_CD"].ToString());
                p.PROD_PUB = dr["PROD_PUB"].ToString();
                p.PROD_DEV = dr["PROD_DEV"].ToString();
                p.PROD_CAT_CD = int.Parse(dr["PROD_CAT_CD"].ToString());
                p.PROD_PRICE = float.Parse(dr["PROD_PRICE"].ToString());
                p.PROD_RATING_CD = int.Parse(dr["PROD_RATING_CD"].ToString());
                p.PROD_DESCR = dr["PROD_DESCR"].ToString();
                p.PROD_IMAGE = dr["PROD_IMAGE"].ToString();
                p.PROD_ADD_DTM = dr["PROD_ADD_DTM"].ToString();
                p.PROD_CHG_DTM = dr["PROD_CHG_DTM"].ToString();
                p.PROD_STAT_CD = dr["PROD_STAT_CD"].ToString();


                productList.AddLast(p);
            }

            return productList.ToArray<Product>();
        }
        public static Product ListProduct(long PROD_ID)
        {
            string strSQL = "SELECT PROD_ID, " +
                                            "PROD_NM, " +
                                                "PROD_PLAT_CD, " +
                                                "PROD_PUB, " +
                                                "PROD_DEV, " +
                                                "PROD_CAT_CD, " +
                                                "PROD_PRICE, " +
                                                "PROD_RATING_CD, " +
                                                "PROD_DESCR, " +
                                                "PROD_IMAGE, " +
                                                "PROD_ADD_DTM, " +
                                                "PROD_CHG_DTM, " +
                                                "PROD_STAT_CD" +
                                                " FROM PRODUCTS_MSTR" +
                                                " WHERE PROD_ID LIKE @PROD_ID;";

            OleDbConnection cn = new OleDbConnection(strConnString);
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbDataReader dr = null;

            OleDbParameter pm = new OleDbParameter("@PROD_ID", OleDbType.Integer);
            pm.Direction = ParameterDirection.Input;
            pm.Value = PROD_ID;
            cm.Parameters.Add(pm);

            cn.Open();
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);


            Product p = new Product();
            while(dr.Read())
            {
                p.PROD_ID = int.Parse(dr["PROD_ID"].ToString());
                p.PROD_NM = dr["PROD_NM"].ToString();
                p.PROD_PLAT_CD = int.Parse(dr["PROD_PLAT_CD"].ToString());
                p.PROD_PUB = dr["PROD_PUB"].ToString();
                p.PROD_DEV = dr["PROD_DEV"].ToString();
                p.PROD_CAT_CD = int.Parse(dr["PROD_CAT_CD"].ToString());
                p.PROD_PRICE = float.Parse(dr["PROD_PRICE"].ToString());
                p.PROD_RATING_CD = int.Parse(dr["PROD_RATING_CD"].ToString());
                p.PROD_DESCR = dr["PROD_DESCR"].ToString();
                p.PROD_IMAGE = dr["PROD_IMAGE"].ToString();
                p.PROD_ADD_DTM = dr["PROD_ADD_DTM"].ToString();
                p.PROD_CHG_DTM = dr["PROD_CHG_DTM"].ToString();
                p.PROD_STAT_CD = dr["PROD_STAT_CD"].ToString();

            }

            return p;
        }
    }
}

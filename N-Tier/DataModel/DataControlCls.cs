using DataModel.NWDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{

    public class Categories
    {
        public int CategoriesID { get; set; }
        public string CategoriesName { get; set; }
        public Bitmap Picture { get; set; }

    }
    public class DataControlCls
    {
        static CategoriesTableAdapter CategoriesAdapter = new CategoriesTableAdapter();
        static NWDataSet nwdataset = new NWDataSet();

        public DataControlCls()
        {
            CategoriesAdapter.Fill(nwdataset.Categories);
        }


        public  DataTable GetCategoriesData()
        {
            return nwdataset.Categories;
        }


        public  List<Categories> Getresult()
        {
            List<Categories> result = new List<Categories>();

            for (int i = 0; i < GetCategoriesData().Rows.Count; i++)
            {
                result.Add(new Categories
                {
                    CategoriesID = (int)(GetCategoriesData().Rows[i][0]),
                    CategoriesName = (GetCategoriesData().Rows[i][1]).ToString(),
                });
            }
            return result;
        }


        static string sqlconn = ConfigurationManager.ConnectionStrings["DataModel.Properties.Settings.NorthwindConnectionString"].ConnectionString;

        public static DataTable GetdataBy(int id)
        {
            string sqlcmd = "Select * from Products where CategoryID = @CategoryID";
            SqlConnection conn = new SqlConnection(sqlconn);
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.Parameters.AddWithValue("@CategoryID", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            conn.Open();

            da.Fill(dataTable);//資料讀入dataTable

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return dataTable;

        }


        public static DataTable GetdataBy(string name)
        {
            string sqlcmd = "Select * from Products where ProductName = @ProductName";
            SqlConnection conn = new SqlConnection(sqlconn);
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.Parameters.AddWithValue("@ProductName", name);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            conn.Open();

            da.Fill(dataTable);//資料讀入dataTable

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return dataTable;

        }

        public static DataTable GetdataBy(decimal Minp, decimal Maxp)
        {
            string sqlcmd = "Select * from Products where UnitPrice BETWEEN @Minp AND @Maxp";
            SqlConnection conn = new SqlConnection(sqlconn);
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.Parameters.AddWithValue("@Minp", Minp);
            cmd.Parameters.AddWithValue("@Maxp", Maxp);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            conn.Open();

            da.Fill(dataTable);//資料讀入dataTable

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return dataTable;
        }
    }

}


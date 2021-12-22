using MVCExample.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCExample.DAL
{
    public class CRUD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        public List<Product> FetchProducts()
        {
            SqlCommand cmd = new SqlCommand("spProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Product> plist = new List<Product>();
            foreach(DataRow drow in dt.Rows)
            {
                Product p = new Product();
                p.id = int.Parse(drow["id"].ToString());
                p.name = drow["name"].ToString();
                p.desc = drow["desc"].ToString();
                plist.Add(p);
            }
            return plist;
        }

        public string InsertProduct(Product p)
        {
            string message = "Successful insertion of record";
            SqlCommand cmd = new SqlCommand("spInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", p.name);
            cmd.Parameters.AddWithValue("@desc", p.desc);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                return message;
            }
            catch(Exception ex)
            {
                message = ex.Message;
                return message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
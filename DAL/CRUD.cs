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
            foreach (DataRow drow in dt.Rows)
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
            catch (Exception ex)
            {
                message = ex.Message;
                return message;
            }
            finally
            {
                con.Close();
            }
        }

        public Product GetProduct(int id)
        {
            SqlCommand cmd = new SqlCommand("spProductByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Product p = new Product();
            p.id = int.Parse(dt.Rows[0]["id"].ToString());
            p.name = dt.Rows[0]["name"].ToString();
            p.desc = dt.Rows[0]["desc"].ToString();
            return p;
        }

        public string EditProduct(Product p)
        {
            string message = "Success";
            SqlCommand cmd = new SqlCommand("update products set [name]='" + p.name + "', [desc]='" + p.desc + "' where id='" + p.id + "'", con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                return message;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return message;
            }
            finally
            {
                con.Close();
            }

        }
        public string DeleteRecord(int id)
        {
            string message = "Deletion Successful";
            SqlCommand cmd = new SqlCommand("delete from products where id='" + id + "'", con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                return message;
            }
            catch (Exception ex)
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
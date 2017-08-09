using Bytes.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bytes.DAL
{
    public class CategoryDAL
    {
        private SqlConnection conn;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            conn = new SqlConnection(constr);
        }

        public bool AddCategory(Category obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddNewCategory", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@categoryName", obj.CategoryName);

            conn.Open();
            int i = com.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }
        }

        public List<Category> GetAllCategories()
        {
            connection();
            List<Category> CategoryList = new List<Category>();
            SqlCommand com = new SqlCommand("GetCategories", conn);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CategoryList.Add(
                    new Category {
                        CategoryID = Convert.ToInt32(dr["categoryID"]),
                        CategoryName = Convert.ToString(dr["categoryName"])
                    }
                    );
            }
            return CategoryList;
        }

        public bool UpdateCategory(Category obj)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdateCategory", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@categoryID", obj.CategoryID);
            com.Parameters.AddWithValue("@categoryName", obj.CategoryName);
            conn.Open();
            int i = com.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCategory(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteCategoryById", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@categoryID", Id);

            conn.Open();
            int i = com.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
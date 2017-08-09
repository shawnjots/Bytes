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
    public class ProductDAL
    {
        private SqlConnection conn;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            conn = new SqlConnection(constr);
        }

        public bool AddProduct(Product obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddNewProduct", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@productName", obj.ProductName);
            com.Parameters.AddWithValue("@categoryID", obj.CategoryID);
            com.Parameters.AddWithValue("@buyingPrice", obj.BuyingPrice);
            com.Parameters.AddWithValue("@sellingPrice", obj.SellingPrice);
            com.Parameters.AddWithValue("@purchaseDate", obj.PurchaseDate);
            com.Parameters.AddWithValue("@expiryDate", obj.ExpiryDate);
            com.Parameters.AddWithValue("@description", obj.Description);

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

        public List<Product> GetAllProducts()
        {
            connection();
            List<Product> ProductList = new List<Product>();

            SqlCommand com = new SqlCommand("GetProducts", conn);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProductList.Add(
                    new Product {
                        ProductID = Convert.ToInt32(dr["productID"]),
                        ProductName = Convert.ToString(dr["productName"]),
                        BuyingPrice = Convert.ToDecimal(dr["buyingPrice"]),
                        SellingPrice = Convert.ToDecimal(dr["sellingPrice"]),
                        PurchaseDate = Convert.ToDateTime(dr["purchaseDate"]),
                        ExpiryDate = Convert.ToDateTime(dr["expiryDate"]),
                        Description = Convert.ToString(dr["description"])
                    });
            }
            return ProductList;
        }

        public bool UpdateProduct(Product obj)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdateProduct", conn);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@productID", obj.ProductID);
            com.Parameters.AddWithValue("@productName", obj.ProductName);
            com.Parameters.AddWithValue("@buyingPrice", obj.BuyingPrice);
            com.Parameters.AddWithValue("@sellingPrice", obj.SellingPrice);
            com.Parameters.AddWithValue("@purchaseDate", obj.PurchaseDate);
            com.Parameters.AddWithValue("@expiryDate", obj.ExpiryDate);
            com.Parameters.AddWithValue("@description", obj.Description);

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

        public bool DeleteProduct(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteProductById", conn);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@productID", Id);

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
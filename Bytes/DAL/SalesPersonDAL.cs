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
    public class SalesPersonDAL
    {
        private SqlConnection conn;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            conn = new SqlConnection(constr);
        }

        public bool AddSalesPerson(SalesPerson obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddNewSalesPerson", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@username", obj.Username);
            com.Parameters.AddWithValue("@password", obj.Password);
            com.Parameters.AddWithValue("@firstName", obj.FirstName);
            com.Parameters.AddWithValue("@lastName", obj.LastName);
            com.Parameters.AddWithValue("@phoneNumber", obj.PhoneNumber);

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

        public List<SalesPerson> GetAllSalesPerson()
        {
            connection();
            List<SalesPerson> SalesPersonList = new List<SalesPerson>();

            SqlCommand com = new SqlCommand("GetSalesPeople", conn);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                SalesPersonList.Add(
                    new SalesPerson
                    {
                        EmployeeID = Convert.ToInt32(dr["employeeID"]),
                        Username = Convert.ToString(dr["username"]),
                        Password = Convert.ToString(dr["password"]),
                        FirstName = Convert.ToString(dr["firstName"]),
                        LastName = Convert.ToString(dr["lastName"]),
                        PhoneNumber = Convert.ToString(dr["phoneNumber"])
                    });
            }
            return SalesPersonList;
        }

        public bool UpdateSalesPerson(SalesPerson obj)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdateSalesPerson", conn);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@employeeID", obj.EmployeeID);
            com.Parameters.AddWithValue("@username", obj.Username);
            com.Parameters.AddWithValue("@password", obj.Password);
            com.Parameters.AddWithValue("@firstName", obj.FirstName);
            com.Parameters.AddWithValue("@lastName", obj.LastName);
            com.Parameters.AddWithValue("@phoneNumber", obj.PhoneNumber);

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

        public bool DeleteSalesPerson(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteByEmployeeId", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@employeeID", Id);

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
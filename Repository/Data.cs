using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillGenerator.Models;
using BillGenerator.Repository;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BillGenerator.Repository
{
    public class Data : IData
    {
        public string ConnString { get; set; }
        public Data()
        {
            ConnString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        }
        public void saveBillDetails(BillDetails details)
        {
            SqlConnection con = new SqlConnection(ConnString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spt_saveEBillDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerName", details.CustomerName);
                cmd.Parameters.AddWithValue("@MobileNumber", details.MobileNumber);
                cmd.Parameters.AddWithValue("@Address", details.Address);
                cmd.Parameters.AddWithValue("@TotalAmount", details.TotalAmount);

                SqlParameter outputPara = new SqlParameter();
                outputPara.DbType = DbType.Int32;
                outputPara.Direction = ParameterDirection.Output;
                outputPara.ParameterName = "@Id";
                cmd.Parameters.Add(outputPara);
                cmd.ExecuteNonQuery();
                int id = int.Parse(outputPara.Value.ToString());
                if (details.Items.Count > 0)
                {
                    saveBillItems(details.Items, con, id);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void saveBillItems(List<Items> items, SqlConnection con, int id)
        {
            try
            {
                string qry = "insert into tbl_BillItems(ProductName, Price, Quantity) values";
                foreach (var item in items)
                {
                    qry += String.Format("('{0}',{1},{2},{3}),",item.ProductName,item.Price,item.Quantity,id);
                }
                qry = qry.Remove(qry.Length-1);
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close ();
            }
        }
    }
}
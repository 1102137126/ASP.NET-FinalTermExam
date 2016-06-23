using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ASP.NET_FinalTermExam.Models
{
    public class EmpService
    {
        /// <summary>
        /// 取得DB連線字串
        /// </summary>
        /// <returns></returns>
        private string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }

        /// <summary>
        /// 取得產品
        /// </summary>
        /// <returns></returns>
        public List<Models.Employee> GetProduct()
        {
            DataTable dt = new DataTable();
            string sql = @"Select ProductId As CodeId,ProductName As CodeName From Production.Products";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapEmpDataToList(dt);
        }



        /// <summary>
		/// 依照條件取得訂單資料
		/// </summary>
		/// <returns></returns>
		public List<Models.Employee> GetEmpByCondtioin(Models.EmpSearchArg arg)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT EmployeeID, FirstName + ' ' + LastName AS EmpName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, Country, Phone, ManagerID, Gender, MonthlyPayment, YearlyPayment
                           FROM HR.Employees 
                           WHERE (EmployeeID Like @EmployeeID Or @EmployeeID='') And 
    						     (Title=@Title Or @Title='')  And 
    						     (HireDate=@HireDate Or @HireDate='')";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@EmployeeID", arg.EmployeeID == null ? string.Empty : arg.EmployeeID));
                //cmd.Parameters.Add(new SqlParameter("@EmpName", arg.EmpName == null ? string.Empty : arg.EmpName));
                cmd.Parameters.Add(new SqlParameter("@Title", arg.Title == null ? string.Empty : arg.Title));
                cmd.Parameters.Add(new SqlParameter("@HireDate", arg.HireDate == null ? string.Empty : arg.HireDate));

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapEmpDataToList(dt);
        }

        /// <summary>
        /// 刪除訂單 By orderId
        /// </summary>
        public void DeleteOrderById(String EmployeeID)
        {
            try
            {
                string sql = "DELETE FROM HR.Employees  Where EmployeeID=@EmployeeID";
                using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Models.Employee> MapEmpDataToList(DataTable empData)
        {
            List<Models.Employee> result = new List<Employee>();

            foreach (DataRow row in empData.Rows)
            {                
                result.Add(new Employee()
                {
                    EmployeeID = (int)row["EmployeeID"],
                    EmpName = row["EmpName"].ToString(),
                    Title = row["Title"].ToString(),
                    //TitleOfCourtesy = row["TitleOfCourtesy"].ToString(),
                    BirthDate = row["BirthDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["BirthDate"],
                    HireDate = row["HireDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["HireDate"],
                    Address = row["Address"].ToString(),
                    //City = row["City"].ToString(),
                    //Region = row["Region"].ToString(),
                    //Country = row["Country"].ToString(),
                    Phone = row["Phone"].ToString(),
                    //ManagerID = (int)row["ManagerID"],
                    Gender = row["Gender"].ToString()
                    //MonthlyPayment = (int)row["MonthlyPayment"],
                    //YearlyPayment = (int)row["YearlyPayment"]
                });
            }
            return result;
        }
    }
}
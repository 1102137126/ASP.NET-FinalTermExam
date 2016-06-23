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
    public class CodeService
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
        /// 取得Title資料
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetTitle()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT CodeId As CodeId,CodeVal As CodeName FROM dbo.CodeTable WHERE CodeType='TITLE'";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {                 
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }

        /// <summary>
        /// 取得City資料
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCity()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT CodeId As CodeId,CodeVal As CodeName FROM dbo.CodeTable WHERE CodeType='CITY'";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }

        /// <summary>
        /// 取得 Gender 資料
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetGender()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT CodeId As CodeId,CodeVal As CodeName FROM dbo.CodeTable WHERE CodeType='GENDER'";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }
        /// <summary>
        /// 取得 Country 資料
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCountry()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT CodeId As CodeId,CodeVal As CodeName FROM dbo.CodeTable WHERE CodeType='COUNTRY'";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }
        /// <summary>
        /// Maping 代碼資料
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<SelectListItem> MapCodeData(DataTable dt)
        {
            List<SelectListItem> result = new List<SelectListItem>();

            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["CodeName"].ToString(),
                    Value = row["CodeId"].ToString(),
                });
            }
            return result;
        }
    }
}
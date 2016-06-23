using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP.NET_FinalTermExam.Models
{
    public class Employee
    {
        /// <summary>
        /// 建構式
        /// </summary>
        public Employee()
        {
        }

        /// <summary>
        /// 員工編號
        /// </summary>

        [DisplayName("員工編號")]
        [Required()]
        public int EmployeeID { get; set; }

        /// <summary>
        /// 員工姓名
        /// </summary>

        [DisplayName("員工姓名")]
        [Required()]
        public string EmpName { get; set; }

        /// <summary>
        /// 職稱編號
        /// </summary>

        [DisplayName("職稱編號")]
        [Required()]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>

        [DisplayName("")]
        [Required()]
        public string TitleOfCourtesy { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>

        [DisplayName("出生日期")]
        [Required()]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// 任職日期
        /// </summary>

        [DisplayName("任職日期")]
        [Required()]
        public DateTime? HireDate { get; set; }

        /// <summary>
        /// 地址
        /// </summary>

        [DisplayName("地址")]
        [Required()]
        public string Address { get; set; }

        /// <summary>
        /// 城市
        /// </summary>

        [DisplayName("城市")]
        [Required()]
        public string City { get; set; }

        /// <summary>
        /// 地區
        /// </summary>

        [DisplayName("地區")]
        [Required()]
        public string Region { get; set; }

        /// <summary>
        /// 國家
        /// </summary>

        [DisplayName("國家")]
        [Required()]
        public string Country { get; set; }

        /// <summary>
        /// 手機號碼
        /// </summary>

        [DisplayName("電話號碼")]
        [Required()]
        public string Phone { get; set; }

        /// <summary>
        /// 經理編號
        /// </summary>

        [DisplayName("經理編號")]
        [Required()]
        public int ManagerID { get; set; }

        /// <summary>
        /// 性別
        /// </summary>

        [DisplayName("性別")]
        [Required()]
        public string Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>

        [DisplayName("")]
        [Required()]
        public int MonthlyPayment { get; set; }

        /// <summary>
        /// 
        /// </summary>

        [DisplayName("")]
        [Required()]
        public int YearlyPayment { get; set; }
    }
}
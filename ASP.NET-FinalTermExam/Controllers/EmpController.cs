using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_FinalTermExam.Models;

namespace ASP.NET_FinalTermExam.Controllers
{
    public class EmpController : Controller
    {
        Models.EmpService empService = new Models.EmpService();
        Models.CodeService codeService = new Models.CodeService();

        /// <summary>
        /// 員工管理首頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.TitleCodeData = this.codeService.GetTitle();
            return View();
        }

        /// <summary>
        /// 取得員工查詢結果
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [HttpPost()]
        public ActionResult Index(Models.EmpSearchArg arg)
        {
            ViewBag.TitleCodeData = this.codeService.GetTitle();
            ViewBag.SearchResult = empService.GetEmpByCondtioin(arg);
            return View("Index");
        }

        /// <summary>
        /// 新增員工的畫面
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertEmp()
        {
            ViewBag.TitleCodeData = this.codeService.GetTitle();
            ViewBag.GenderCodeData = this.codeService.GetGender();
            ViewBag.CityCodeData = this.codeService.GetCity();
            ViewBag.CountryCodeData = this.codeService.GetCountry();
            return View(new Models.Employee());
        }







    }
}

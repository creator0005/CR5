using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hinh1.Models;

namespace Hinh1.Controllers
{
    public class HomeController : Controller
    {
        HinhAnhDataContext ha = new HinhAnhDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult DanhSach() 
            {
            List<Hinhanh> h = ha.Hinhanhs.ToList();
            return View(h);
            }
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                Hinhanh p = new Hinhanh();              
                HttpPostedFileBase file = Request.Files["Hinhanh"];
                if (file != null)
                {
                    string ServerPath = HttpContext.Server.MapPath("~/hinh1");
                    string filePath = ServerPath + "/" + file.FileName;
                    file.SaveAs(filePath);
                    p.Hinh = file.FileName;
                }
                ha.Hinhanhs.InsertOnSubmit(p);
                ha.SubmitChanges();
                return RedirectToAction("DanhSach");
            }
            return View();
        }
    }
}
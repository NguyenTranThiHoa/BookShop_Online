using BookShop_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop_Online.Controllers
{
    public class QLChuDeController : Controller
    {
        // GET: QLChuDe
        private ModelBookShop _context = new ModelBookShop();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartalChuDe()
        {
            //var lstCD = _context.ChuDes.Take(10).ToList();
            //int sluong = lstCD.Count();

            var lstCD = _context.ChuDes.Take(10).OrderBy(x => x.TenChuDe).ToList();

            //ViewBag.soluong = sluong;
            
            return PartialView(lstCD);
        }
    }
}
using BookShop_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop_Online.Controllers
{
    public class QLNhaXuatBanController : Controller
    {
        // GET: QLNhaXuatBan
        private ModelBookShop _context = new ModelBookShop();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartalNhaXuatBan()
        {
            var lstNXB = _context.NhaXuatBans.Take(10).ToList();
            int sluong = lstNXB.Count();
            ViewBag.soluong = sluong;
            return PartialView(lstNXB);
        }
    }
}
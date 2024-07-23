using BookShop_Online.Areas.Admin.Data;
using BookShop_Online.Models;
using System.Linq;
using System.Web.Mvc;

namespace BookShop_Online.Areas.Admin.Controllers
{
    public class QLChuDeAdminController : Controller
    {
        // GET: Admin/QLChuDeAdmin

        private ModelBookShop _context = new ModelBookShop();
        public ActionResult Index()
        {
            var lstCD = (from cd in _context.ChuDes
                        //orderby cd.TenChuDe

                        // Hoặc có thể sắp xếp theo "Mã chủ đề" từ cao đến thấp
                        orderby cd.MaChuDe descending
                        select new ChuDeVM()
                        {
                            MaCD = cd.MaChuDe,
                            TenCD = cd.TenChuDe
                        }).ToList();

            return View(lstCD);
        }

        [HttpGet] // xử lý giao diện
        public ActionResult AddChuDe()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddChuDe(ChuDeVM formData)
        {
            var item = new ChuDe();
            item.TenChuDe = formData.TenCD;

            // Thêm vào
            _context.ChuDes.Add(item);

            _context.SaveChanges(); // save đến cơ sở dữ liệu

            return RedirectToAction("Index", "QLChuDeAdmin");
        }

        [HttpGet]
        public ActionResult EditChuDe(int id)
        {
            // Có sẵn thì dùng cách này
            //var cd = _context.ChuDes.Where(x => x.MaChuDe == id).Select(item => new ChuDeVM()
            //{
            //    MaCD = item.MaChuDe,
            //    TenCD = item.TenChuDe
            //}).FirstOrDefault();

            // Còn mà kết bảng nối bảng thì dùng cách này
            var cd = (from item in _context.ChuDes
                      where item.MaChuDe == id
                      select new ChuDeVM()
                      {
                          MaCD = item.MaChuDe,
                          TenCD = item.TenChuDe
                      }).FirstOrDefault();

            if (cd == null)
            {
                return RedirectToAction("Index", "QLChuDeAdmin");
            }
            return View(cd);
        }

        [HttpPost]
        public ActionResult EditChuDe( ChuDeVM formData)
        {
            var item = _context.ChuDes.Where(x => x.MaChuDe == formData.MaCD).FirstOrDefault();

            if (item == null){
                return RedirectToAction("Index", "QLChuDeAdmin"); 
            }

            item.TenChuDe = formData.TenCD;

            _context.SaveChanges();
            return RedirectToAction("Index", "QLChuDeAdmin");
        }

        public ActionResult DeTaiChuDe(int id)
        {
            var item = _context.ChuDes.Where(x => x.MaChuDe == id).Select(x => new ChuDeVM()
            {
                MaCD = x.MaChuDe,
                TenCD = x.TenChuDe
            }).FirstOrDefault();
            return View(item);
        }

        [HttpGet]
        public ActionResult DeleteChuDe(int id)
        {
            var item = _context.ChuDes.Where(x => x.MaChuDe == id).Select(x => new ChuDeVM()
            {
                MaCD = x.MaChuDe,
                TenCD = x.TenChuDe
            }).FirstOrDefault();
            return View(item); 
        }

        [HttpPost]
        public ActionResult DeleteChuDe(ChuDeVM formData)
        {
            var item = _context.ChuDes.Where(x => x.MaChuDe == formData.MaCD).FirstOrDefault();

            if (item == null)
            {
                return RedirectToAction("Index", "QLChuDeAdmin");
            }

            item.MaChuDe = formData.MaCD;
            _context.ChuDes.Remove(item);

            _context.SaveChanges();

            return RedirectToAction("Index", "QLChuDeAdmin");
        }
    }
}
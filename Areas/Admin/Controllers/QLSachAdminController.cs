using BookShop_Online.Areas.Admin.Data;
using BookShop_Online.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BookShop_Online.Areas.Admin.Controllers
{
    public class QLSachAdminController : Controller
    {
        // GET: Admin/QLSachAdmin
        private ModelBookShop _context = new ModelBookShop();
        public ActionResult Index()
        {
            var lstBook = (from s in _context.Saches
                          join cd in _context.ChuDes on s.MaChuDe equals cd.MaChuDe into cdtemp
                          join nxb in _context.NhaXuatBans on s.MaNXB equals nxb.MaNXB into nxbtemp
                          from cdf in cdtemp.DefaultIfEmpty()
                          from nxbf in nxbtemp.DefaultIfEmpty()
                          orderby s.NgayCapNhat descending
                          select new SachDisplayVM()
                          {
                              MaSach = s.MaSach,
                              TenSach = s.TenSach,
                              GiaBan = s.GiaBan,
                              NgayCapNhat = s.NgayCapNhat,
                              TenChuDe = cdf != null ? cdf.TenChuDe: "",
                              TenNhaXuatBan = nxbf != null ? nxbf.TenNXB: "",
                              AnhBia = s.AnhBia,
                              SoLuongTon = s.SoLuongTon
                          }).ToList();
            ViewBag.message = lstBook.Count();
            return View(lstBook);
        }

        [HttpGet] // xử lý giao diện
        public ActionResult AddBook()
        {
            var lstChuDe = _context.ChuDes.OrderBy(x => x.TenChuDe).ToList();
            var lstNXB = _context.NhaXuatBans.OrderBy(x => x.TenNXB).ToList();

            ViewBag.MaChuDe = new SelectList(lstChuDe, "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(lstNXB, "MaNXB", "TenNXB");
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(SachVM formData, HttpPostedFileBase fileUpload)
        {
            var itemNew = new Sach();
            itemNew.TenSach = formData.TenSach;
            itemNew.GiaBan = formData.GiaBan;
            itemNew.MoTa = formData.MoTa;
            itemNew.NgayCapNhat = formData.NgayCapNhat;
            itemNew.MaChuDe = formData.MaChuDe;
            itemNew.MaNXB = formData.MaNXB;
            itemNew.SoLuongTon = formData.SoLuongTon;
            itemNew.NgayCapNhat = DateTime.Now;
            itemNew.Moi = 1;
            //itemNew.AnhBia = "";

            // get fileName
            var fileName = System.IO.Path.GetFileName(fileUpload.FileName);
            //get path
            var path = Path.Combine(Server.MapPath("~/Images/Image_Books/"), fileName);
            // Kiểm tra file có tồn tại ko?
            if (System.IO.File.Exists(path))
            {
                ViewBag.message = "Ảnh này đã tồn tại";
            }
            else
            {
                fileUpload.SaveAs(path);
            }

            itemNew.AnhBia = fileName;

            // Thêm vào
            _context.Saches.Add(itemNew);

            _context.SaveChanges(); // save đến cơ sở dữ liệu

            return RedirectToAction("Index", "QLSachAdmin");
        }

        public ActionResult DetailSach(int id)
        {
            var item = _context.Saches.Where(x => x.MaSach == id).Select(x => new SachVM()
            {
                TenSach = x.TenSach,
                GiaBan = x.GiaBan,
                NgayCapNhat = x.NgayCapNhat,
                //TenChuDe = x.TenChuDe,
                //TenNhaXuatBan = x.TenNhaXuatBan;
                SoLuongTon = x.SoLuongTon,
                //TenChuDe = x.TenChuDe
            }).FirstOrDefault();
            return View(item);
        }

        [HttpGet]
        public ActionResult DeleteBook(int id)
        {
            var item = _context.Saches.Where(x => x.MaSach == id).Select(x => new SachVM()
            {
                MaSach = x.MaSach,
                TenSach = x.TenSach,
                GiaBan = x.GiaBan,
                MoTa = x.MoTa,
                SoLuongTon = x.SoLuongTon,
                NgayCapNhat = x.NgayCapNhat,
                AnhBia = x.AnhBia,
                MaChuDe = x.MaChuDe,
                MaNXB = x.MaNXB,
                Moi = x.Moi
            }).FirstOrDefault();
            return View(item);
        }

        [HttpPost, ActionName("DeleteBook")]
        public ActionResult DeleteBook_1(int id)
        {
            var item = _context.Saches.Where(x => x.MaSach == id).FirstOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index", "QLSachAdmin");
            }

            _context.Saches.Remove(item);
            _context.SaveChanges();

             return RedirectToAction("Index", "QLSachAdmin");
        }
    }
}
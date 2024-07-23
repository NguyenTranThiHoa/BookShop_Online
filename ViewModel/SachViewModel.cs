using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop_Online.ViewModel
{
    public class SachViewModel
    {
        public string TenSach { get; set; }
        public decimal? GiaBan { get; set; }
        public  string MoTa { get; set;}
        public int? SoLuongCon { get; set; }
        public DateTime? NgayNhap { get; set; }
        public string AnhBia { get; set; }
        public string TenCD { get; set; }
        public string TenNXB { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop_Online.Areas.Admin.Data
{
    public class SachVM
    {
        [DisplayName("Mã sách")]
        public int MaSach { get; set; }

        [DisplayName("Tên sách")]        
        public string TenSach { get; set; }

        [Display(Name = "Giá bán")]
        public decimal? GiaBan { get; set; }

        [Display(Name= "Mô tả"), DataType(DataType.MultilineText)]
        public string MoTa { get; set; }

        [Display(Name = "Số lượng tồn")]
        public int? SoLuongTon { get; set; }

        [Display(Name = "Ngày cập nhật"), DataType(DataType.Date)]
        public DateTime? NgayCapNhat { get; set; }

        [Display(Name = "Ảnh bìa")]
        public string AnhBia { get; set; }

        [Display(Name = "Mã chủ đề")]
        public int? MaChuDe { get; set; }

        [Display(Name = "Nhà xuất bản")]
        public int? MaNXB { get; set; }
        public int? Moi { get; set; }
    }
}
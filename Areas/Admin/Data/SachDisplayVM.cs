using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop_Online.Areas.Admin.Data
{
    public class SachDisplayVM
    {
        public int MaSach { get; set; }

        [DisplayName("Tên sách")]
        public string TenSach { get; set; }

        [DisplayName("Giá bán"),DataType(DataType.Currency)]
        public decimal? GiaBan { get; set; }

        [DisplayName("Số lượng còn")]
        public int? SoLuongTon { get; set; }

        [DisplayName("Ảnh bìa")]
        public string AnhBia { get; set; }

        [DisplayName("Ngày cập nhật"), DataType(DataType.Date)]
        public DateTime? NgayCapNhat { get; set; }

        [DisplayName("Tên chủ đề")]
        public string TenChuDe { get; set; }

        [DisplayName("Tên nhà xuất bản")]
        public string TenNhaXuatBan { get; set; }
    }
}
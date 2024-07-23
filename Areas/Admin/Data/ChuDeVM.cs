using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BookShop_Online.Areas.Admin.Data
{
    public class ChuDeVM
    {
        // có thể có cách khác
        //[Display(Name = "Mã chủ đề")]

        [DisplayName("Mã chủ đề")]
        public int MaCD { get; set; }

        [DisplayName("Tên chủ đề")]
        public string TenCD { get; set; }
    }
}
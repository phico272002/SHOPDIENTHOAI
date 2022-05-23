using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPDienThoai.Models
{
    public class DienThoai
    {
        public int Id { get; set; }
        [Display (Name ="Tên Sản Phẩm")]
        public string Title { get; set; }
        [Display(Name = "Loại Sản Phẩm")]
        public string Genre { get; set; }
        [Display(Name = "Màu Sắc")]
        public string Color { get; set; }
        [Display(Name = "Giá Tiền")]
        public decimal Price { get; set; }
    }
}

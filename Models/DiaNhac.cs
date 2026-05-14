using System.ComponentModel.DataAnnotations;

namespace ExamWeb_TrungLap.Models
{
    public class DiaNhac
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tựa đề không được bỏ trống")]
        [StringLength(250)]
        public string TuaCD { get; set; }

        [Required(ErrorMessage = "Nghệ sĩ không được bỏ trống")]
        [StringLength(50)]
        public string NgheSi { get; set; }

        public bool TrongNuoc { get; set; }

        [Required(ErrorMessage = "Giá bán không được bỏ trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá bán là số thực > 0")]
        public double GiaBan { get; set; }

        [Required(ErrorMessage = "Số lượng không được bỏ trống")]
        [Range(1, 200, ErrorMessage = "Số lượng là số nguyên từ 1 đến 200")]
        public int SoLuong { get; set; }
    }
}

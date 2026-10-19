using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cau4_QuanLyTraSua.Models
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHD { get; set; }

        public DateTime NgayLap { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,0)")]
        public decimal TongTien { get; set; }

        [Required]
        [MaxLength(20)]
        public string HinhThucTT { get; set; } = "Tiền mặt"; // 'Tiền mặt' / 'Chuyển khoản'

        public bool DaThanhToan { get; set; } = true;

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
    }
}

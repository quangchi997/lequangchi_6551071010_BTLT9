using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cau2_QuanLyNhaTro.Models
{
    [Table("KhachThue")]
    public class KhachThue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaKhach { get; set; }

        [Required]
        [MaxLength(100)]
        public string HoTen { get; set; } = string.Empty;

        [Required]
        [MaxLength(5)]
        public string GioiTinh { get; set; } = "Nam"; // 'Nam' / 'Nữ'

        [Required]
        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [MaxLength(15)]
        public string SoDienThoai { get; set; } = string.Empty;

        public int MaTinh { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenTinh { get; set; } = string.Empty;

        public int MaPhuongXa { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenPhuongXa { get; set; } = string.Empty;

        public bool DaDangKyTamTru { get; set; }

        [ForeignKey("PhongTro")]
        public int MaPhong { get; set; }

        // Navigation property
        public virtual PhongTro PhongTro { get; set; } = null!;
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cau2_QuanLyNhaTro.Models
{
    [Table("PhongTro")]
    public class PhongTro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhong { get; set; }

        [Required]
        [MaxLength(20)]
        public string TenPhong { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,0)")]
        public decimal GiaThue { get; set; }

        [Required]
        [MaxLength(20)]
        public string TinhTrang { get; set; } = "Trống";

        // Navigation property
        public virtual ICollection<KhachThue> KhachThues { get; set; } = new List<KhachThue>();

        public override string ToString() => $"{TenPhong} - {GiaThue:N0} đ";
    }
}

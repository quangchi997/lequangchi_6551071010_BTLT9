using System.ComponentModel.DataAnnotations.Schema;

namespace Cau4_QuanLyTraSua.Models
{
    [Table("ChiTietHoaDon")]
    public class ChiTietHoaDon
    {
        [ForeignKey("HoaDon")]
        public int MaHD { get; set; }

        [ForeignKey("MonUong")]
        public int MaMon { get; set; }

        public int SoLy { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal DonGia { get; set; }

        public virtual HoaDon HoaDon { get; set; } = null!;
        public virtual MonUong MonUong { get; set; } = null!;
    }
}

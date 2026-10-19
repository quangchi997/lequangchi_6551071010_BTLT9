using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cau4_QuanLyTraSua.Models
{
    [Table("MonUong")]
    public class MonUong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaMon { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenMon { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,0)")]
        public decimal GiaBan { get; set; }

        public bool DangBan { get; set; } = true;

        [ForeignKey("DanhMucMon")]
        public int MaDM { get; set; }

        public virtual DanhMucMon DanhMucMon { get; set; } = null!;
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

        public override string ToString() => $"{TenMon} - {GiaBan:N0} đ";
    }
}

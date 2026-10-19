using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cau4_QuanLyTraSua.Models
{
    [Table("DanhMucMon")]
    public class DanhMucMon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDM { get; set; }

        [Required]
        [MaxLength(50)]
        public string TenDM { get; set; } = string.Empty;

        public virtual ICollection<MonUong> MonUongs { get; set; } = new List<MonUong>();

        public override string ToString() => TenDM;
    }
}

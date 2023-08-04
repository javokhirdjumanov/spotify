using spotify.datalayer.pgsql;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WEBASE.Models;

namespace spotify.datalayer.EfClasses
{
    [Table("enum_otp_code_status", Schema = "adm")]
    public class OtpCodeStatus : IHaveIdProp<int>
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("code_status")]
        [StringLength(50)]
        public string CodeStatus { get; set; } = null!;

        [InverseProperty("OtpCodeStatus")]
        public virtual ICollection<OtpCode> OtpCodes { get; set; } = new List<OtpCode>();
    }
}

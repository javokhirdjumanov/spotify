using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace spotify.datalayer.pgsql;

[Table("enum_otp_code_status")]
public partial class EnumOtpCodeStatus
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code_status")]
    [StringLength(50)]
    public string CodeStatus { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<HlOtpCode> HlOtpCodes { get; set; } = new List<HlOtpCode>();
}

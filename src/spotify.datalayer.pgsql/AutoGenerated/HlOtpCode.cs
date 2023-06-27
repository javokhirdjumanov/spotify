using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace spotify.datalayer.pgsql;

[Table("hl_otp_code")]
public partial class HlOtpCode
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(10)]
    public string Code { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("HlOtpCodes")]
    public virtual EnumOtpCodeStatus Status { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("HlOtpCodes")]
    public virtual HlUser User { get; set; } = null!;
}

﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEBASE.Models;

namespace spotify.datalayer.EfClasses;
[Table("hl_otp_code", Schema = "hl_otp_code")]

public class OtpCode : IHaveIdProp<int>
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(10)]
    public string Code { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("status_id")]
    public int OtpCodeStatusId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [ForeignKey("OtpCodeStatusId")]
    [InverseProperty("OtpCodes")]
    public virtual OtpCodeStatus OtpCodeStatus { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("OtpCodes")]
    public virtual User User { get; set; } = null!;
}

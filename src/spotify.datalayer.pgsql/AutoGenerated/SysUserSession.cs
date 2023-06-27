using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace spotify.datalayer.pgsql;

[Table("sys_user_session")]
public partial class SysUserSession
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("token")]
    [StringLength(255)]
    public string Token { get; set; } = null!;

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("SysUserSessions")]
    public virtual EnumSessionStatus Status { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("SysUserSessions")]
    public virtual HlUser User { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace spotify.datalayer.pgsql;

[Table("hl_user")]
public partial class HlUser
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column("phone")]
    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("role_id")]
    public int RoleId { get; set; }

    [Column("salt")]
    [StringLength(255)]
    public string Salt { get; set; } = null!;

    [Column("refresh_token")]
    [StringLength(255)]
    public string? RefreshToken { get; set; }

    [Column("refresh_token_expire_date", TypeName = "timestamp without time zone")]
    public DateTime? RefreshTokenExpireDate { get; set; }

    [Column("password_hash")]
    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [Column("registered_at", TypeName = "timestamp without time zone")]
    public DateTime? RegisteredAt { get; set; }

    [Column("last_login", TypeName = "timestamp without time zone")]
    public DateTime? LastLogin { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("state_id")]
    public int? StateId { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<HlOtpCode> HlOtpCodes { get; set; } = new List<HlOtpCode>();

    [ForeignKey("RoleId")]
    [InverseProperty("HlUsers")]
    public virtual EnumUserRole Role { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("HlUsers")]
    public virtual EnumState? State { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("HlUsers")]
    public virtual EnumStatus Status { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<SysUserSession> SysUserSessions { get; set; } = new List<SysUserSession>();
}

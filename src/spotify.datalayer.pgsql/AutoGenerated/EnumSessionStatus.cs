using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace spotify.datalayer.pgsql;

[Table("enum_session_status")]
public partial class EnumSessionStatus
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("session_status_name")]
    [StringLength(50)]
    public string SessionStatusName { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<SysUserSession> SysUserSessions { get; set; } = new List<SysUserSession>();
}

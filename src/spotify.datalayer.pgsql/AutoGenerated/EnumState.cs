using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace spotify.datalayer.pgsql;

[Table("enum_state")]
public partial class EnumState
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("state_name")]
    [StringLength(50)]
    public string StateName { get; set; } = null!;

    [InverseProperty("State")]
    public virtual ICollection<HlUser> HlUsers { get; set; } = new List<HlUser>();
}

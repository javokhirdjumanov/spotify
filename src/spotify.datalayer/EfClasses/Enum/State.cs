﻿using spotify.datalayer.pgsql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEBASE.Models;

namespace spotify.datalayer.EfClasses
{
    [Table("enum_state", Schema = "adm")]
    public class State : IHaveIdProp<int>
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("state_name")]
        [StringLength(50)]
        public string StateName { get; set; } = null!;

        [InverseProperty("State")]
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}

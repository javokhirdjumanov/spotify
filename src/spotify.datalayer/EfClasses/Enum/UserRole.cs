using spotify.datalayer.pgsql;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace spotify.datalayer.EfClasses
{
    [Table("enum_user_role")]

    public class UserRole
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("role_name")]
        [StringLength(50)]
        public string RoleName { get; set; } = null!;

        [InverseProperty("Role")]
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}

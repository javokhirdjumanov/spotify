using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEBASE.Models;

namespace spotify.datalayer.EfClasses
{
    [Table("enum_user_role", Schema = "adm")]

    public class UserRole : IHaveIdProp<int>
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

using spotify.datalayer.pgsql;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WEBASE.Models;

namespace spotify.datalayer.EfClasses
{
    [Table("enum_session_status")]
    public class SessionStatus : IHaveIdProp<int>
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("session_status_name")]
        [StringLength(50)]
        public string SessionStatusName { get; set; } = null!;

        [InverseProperty("SessionStatus")]
        public virtual ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();
    }
}

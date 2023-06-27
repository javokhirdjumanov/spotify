using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEBASE.Models;

namespace spotify.datalayer.EfClasses
{
    public class UserSession : IHaveIdProp<int>
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("token")]
        [StringLength(255)]
        public string Token { get; set; } = null!;

        [Column("status_id")]
        public int SessionStatusId { get; set; }

        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("SessionStatusId")]
        [InverseProperty("UserSessions")]
        public virtual SessionStatus SessionStatus { get; set; } = null!;

        [ForeignKey("UserId")]
        [InverseProperty("UserSessions")]
        public virtual User User { get; set; } = null!;
    }
}

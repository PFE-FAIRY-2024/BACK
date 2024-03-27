using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace timsoft.entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Password { get; set; }
        public ERole role { get; set; }

    }

    public enum ERole
    {
        RoleAdmin,
        RoleClient,
        RoleProfessionnel
    }
}

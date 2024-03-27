using timsoft.entities;

namespace ConsultationBack.dto
{
    public class UserForm
    {
        public string? Username { get; set; }
        public string? Nom { get; set; }
        public string? Prénom { get; set; }
        public string Password { get; set; }
        public ERole role { get; set; }

    }
}

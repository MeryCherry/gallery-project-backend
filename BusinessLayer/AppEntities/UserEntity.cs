using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.AppEntities
{
    public class UserEntity : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdRole { get; set; }
        public byte[] Password { get; set; }
        public string ProfilePictName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public RoleEntity IdRoleNavigation { get; set; }
    }
}

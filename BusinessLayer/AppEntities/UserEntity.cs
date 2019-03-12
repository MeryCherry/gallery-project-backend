using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.AppEntities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdRole { get; set; }
        public byte[] Password { get; set; }
        public string ProfilePictName { get; set; }
        public string Email { get; set; }

        public RoleEntity IdRoleNavigation { get; set; }
    }
}

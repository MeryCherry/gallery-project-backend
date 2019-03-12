using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.AppEntities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanRegister { get; set; }
        public bool CanResetPass { get; set; }
        public bool CanEditProfile { get; set; }
        public bool HasCart { get; set; }
        public bool CanDisplayList { get; set; }
        public bool CanManageItems { get; set; }
        public bool CanSetPromotion { get; set; }
        public bool CanManageOrder { get; set; }
        public bool CanManageUsers { get; set; }
        public bool CanManageUserRole { get; set; }
        public bool CanManageDeliveryOption { get; set; }
        public bool CanManagePaymentOption { get; set; }
    }
}

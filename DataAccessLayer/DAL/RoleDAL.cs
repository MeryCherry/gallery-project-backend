using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class RoleDAL : BaseEntityDAL<Role, RoleEntity>
    {
        public RoleDAL(IOptions<AppSettingsModel> settings) : base(settings) { }

    }
}
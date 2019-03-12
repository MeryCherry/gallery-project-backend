using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class UserDAL : BaseEntityDAL<Users,UserEntity>
    {
        public UserDAL(IOptions<AppSettingsModel> settings) : base(settings){ }

    }
}

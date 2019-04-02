using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class DeliveryDetailsDAL : BaseEntityDAL<DeliveryDetails, DeliveryDetailsEntity>
    {
        public DeliveryDetailsDAL(IOptions<AppSettingsModel> settings) : base(settings) { }

    }
}
using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class DeliveryOptionDAL : BaseEntityDAL<DeliveryOption, DeliveryOptionEntity>
    {
        public DeliveryOptionDAL(IOptions<AppSettingsModel> settings) : base(settings) { }

    }
}
using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class PaymentOptionDAL : BaseEntityDAL<PaymentOption, PaymentOptionEntity>
    {
        public PaymentOptionDAL(IOptions<AppSettingsModel> settings) : base(settings) { }

    }
}
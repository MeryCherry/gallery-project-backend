using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class CurrencyDAL : BaseEntityDAL<Currency, CurrencyEntity>
    {
        public CurrencyDAL(IOptions<AppSettingsModel> settings) : base(settings) { }

    }
}
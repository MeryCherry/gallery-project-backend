using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class ShoppingCartDAL : BaseEntityDAL<ShoppingCart, ShoppingCartEntity>
    {
        public ShoppingCartDAL(IOptions<AppSettingsModel> settings) : base(settings) { }

    }
}

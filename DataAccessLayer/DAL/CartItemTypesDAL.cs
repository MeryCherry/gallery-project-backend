using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class CartItemTypesDAL : BaseEntityDAL<CartItemTypes, CartItemTypesEntity>
    {

        public CartItemTypesDAL(IOptions<AppSettingsModel> settings) : base(settings) { }
    }
}

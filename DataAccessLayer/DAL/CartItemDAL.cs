using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class CartItemDAL : BaseEntityDAL<CartItem, CartItemEntity>
    {

        public CartItemDAL(IOptions<AppSettingsModel> settings) : base(settings) { }
    }
}
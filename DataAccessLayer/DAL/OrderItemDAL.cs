using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class OrderItemDAL : BaseEntityDAL<OrderItem, OrderItemEntity>
    {
        public OrderItemDAL(IOptions<AppSettingsModel> settings) : base(settings) { }

    }
}
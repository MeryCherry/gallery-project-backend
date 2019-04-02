using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class OrderStatusDAL : BaseEntityDAL<OrderStatus, OrderStatusEntity>
    {
        public OrderStatusDAL(IOptions<AppSettingsModel> settings) : base(settings) { }

    }
}
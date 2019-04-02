using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class OrderTbDAL : BaseEntityDAL<OrderTb, OrderTbEntity>
    {
        public OrderTbDAL(IOptions<AppSettingsModel> settings) : base(settings) { }

    }
}
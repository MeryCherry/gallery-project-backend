using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.Models;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.DAL
{
    public class SellItemDAL : BaseEntityDAL<SellItem, SellItemEntity>
    {
        public SellItemDAL(IOptions<AppSettingsModel> settings) : base(settings) { }

    }
}
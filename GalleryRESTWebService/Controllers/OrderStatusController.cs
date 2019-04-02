using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : BaseController<OrderStatusDAL, OrderStatusEntity>
    {
        public OrderStatusController(IOptions<AppSettingsModel> settings) : base(settings) { }
    }
}
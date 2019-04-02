using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTbController : BaseController<OrderTbDAL, OrderTbEntity>
    {
        public OrderTbController(IOptions<AppSettingsModel> settings) : base(settings) { }
    }
}
using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryDetailsController : BaseController<DeliveryDetailsDAL, DeliveryDetailsEntity>
    {
        public DeliveryDetailsController(IOptions<AppSettingsModel> settings) : base(settings) { }
    }
}
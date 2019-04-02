using BusinessLayer.AppEntities;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryDetailsController : BaseController<DeliveryDetailsDAL, DeliveryDetailsEntity>
    {
        public DeliveryDetailsController(IEntityDALFactory factory) : base(factory) { }
    }
}
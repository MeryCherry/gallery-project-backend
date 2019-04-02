using BusinessLayer.AppEntities;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : BaseController<OrderStatusDAL, OrderStatusEntity>
    {
        public OrderStatusController(IEntityDALFactory factory) : base(factory) { }
    }
}
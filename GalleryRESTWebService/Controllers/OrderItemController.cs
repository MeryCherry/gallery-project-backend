using BusinessLayer.AppEntities;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : BaseController<OrderItemDAL, OrderItemEntity>
    {
        public OrderItemController(IEntityDALFactory factory) : base(factory) { }
    }
}
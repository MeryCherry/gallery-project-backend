using BusinessLayer.AppEntities;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTbController : BaseController<OrderTbDAL, OrderTbEntity>
    {
        public OrderTbController(IEntityDALFactory factory) : base(factory) { }
    }
}
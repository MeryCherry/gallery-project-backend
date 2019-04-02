using BusinessLayer.AppEntities;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : BaseController<ShoppingCartDAL, ShoppingCartEntity>
    {
        public ShoppingCartController(IEntityDALFactory factory) : base(factory) { }
    }
}
using BusinessLayer.AppEntities;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : BaseController<CartItemDAL, CartItemEntity>
    {
        public CartItemController(IEntityDALFactory factory) : base(factory) { }
    }
}
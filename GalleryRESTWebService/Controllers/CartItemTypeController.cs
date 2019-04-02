using BusinessLayer.AppEntities;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemTypeController : BaseController<CartItemTypesDAL, CartItemTypesEntity>
    {
        public CartItemTypeController(IEntityDALFactory factory) : base(factory) { }
    }
}
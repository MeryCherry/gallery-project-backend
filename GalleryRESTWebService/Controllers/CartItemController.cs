using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : BaseController<CartItemDAL, CartItemEntity>
    {
        public CartItemController(IOptions<AppSettingsModel> settings) : base(settings) { }
    }
}
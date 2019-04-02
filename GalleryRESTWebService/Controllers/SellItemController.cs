using BusinessLayer.AppEntities;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellItemController : BaseController<SellItemDAL, SellItemEntity>
    {
        public SellItemController(IEntityDALFactory factory) : base(factory) { }
    }
}
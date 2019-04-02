using BusinessLayer.AppEntities;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : BaseController<CurrencyDAL, CurrencyEntity>
    {
        public CurrencyController(IEntityDALFactory factory) : base(factory) { }
    }
}
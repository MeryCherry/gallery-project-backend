using BusinessLayer.AppEntities;
using DataAccessLayer.DAL;
using DataAccessLayer.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController<UserDAL,UserEntity>
    {
        public UserController(IEntityDALFactory factory) :base(factory) { }
    }
}

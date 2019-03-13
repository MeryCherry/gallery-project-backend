using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GalleryRESTWebService.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController<UserDAL,UserEntity>
    {
        public UserController(IOptions<AppSettingsModel> settings):base(settings) { }
    }
}

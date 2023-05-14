using Letsgrow.Service;
using Letsgrow.Webapi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;

namespace Letsgrow.WebApi.Controllers
{
    public class HomeController : BaseController
    {
         private IUserService _userService;
        public HomeController(IUserService userService)
        {
          _userService = userService;
        }



    }
}

using Letsgrow.Model;
using Letsgrow.Service;
using Letsgrow.Webapi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Letsgrow.WebApi.Controllers.UserController
{

    public class UserController : BaseController
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet]

        public IActionResult GetUsers(string json)
        {

            var result = _userService.GetAllUser().Result;
            return Ok(result.Json);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] MUser user)
        {
            var result = _userService.CreateUser(user).Result;
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Letsgrow.Webapi.Controllers.Base
{
    [ApiController]
    [EnableCors]
    [Route("api/[controller]/[action]/{id?}")]
    public class BaseController : Controller
    {

    }
}

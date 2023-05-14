using Microsoft.AspNetCore.Mvc;
using Letsgrow.Webapi.Controllers.Base;
using Letsgrow.Service;
using Letsgrow.Service.Gallery;

namespace Letsgrow.WebApi.Controllers.GalleryController
{
    public class GalleryController : BaseController
    {
        IGalleryService _galleryService;
        IUserService _userService;



        public GalleryController(IGalleryService galleryService, IUserService userService)
        {
            _galleryService = galleryService;
            _userService = userService;

        }

        [HttpGet]

        public IActionResult GetPlants(string json)
        {
            //if any parameter needs to be sent in the json string for now no paramter.
            var result = _galleryService.GetAllPlants().Result;
            return Ok(result.Json);
        }


        [HttpGet]
        public IActionResult PlantImagesFromRepo(string id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                var repoPath = _userService.GetFileRepositoryPath();

                string folder = "plants";

                var relPath = string.Format("{0}", folder);

                var fullDirPath = Path.Combine(repoPath, relPath);

                if (Directory.Exists(fullDirPath))
                {
                    relPath = string.Format("{0}", folder);
                    var fileDir = string.Format("{0}/{1}", repoPath, relPath);
                    fullDirPath = Path.GetFullPath(fileDir);

                    FileInfo[] fInfo = new DirectoryInfo(fullDirPath).GetFiles();
                    var file = fInfo.FirstOrDefault(x => x.Name.StartsWith("plant" + id));
                    if (file != null)
                    {
                        var imgContentType = string.Format("image/{0}", file.Extension.Replace(".", ""));
                        var img = System.IO.File.OpenRead(file.FullName);
                        return File(img, imgContentType);
                    }
                }


                var noLogoImg = System.IO.File.OpenRead(Path.Combine(repoPath, "transparent.png"));
                return File(noLogoImg, "image/png");
            }
            catch (Exception ex)
            {

                return Ok(false);
            }
        }


    }
}

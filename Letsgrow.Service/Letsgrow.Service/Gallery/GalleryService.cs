using Letsgrow.Data.Repository;
using Letsgrow.Service.Gallery;

namespace Letsgrow.Service
{
    public class GalleryService : IGalleryService
    {

    
        private IGalleryRepository _galleryRepository;
        private IConfiguration _configuration;
        public GalleryService(IGalleryRepository galleryRepository, IConfiguration configuration)
        {

            this._galleryRepository = galleryRepository;
            this._configuration = configuration;
        }
        public async Task<dynamic> GetAllPlants()
        {

            return await _galleryRepository.GetAllPlantAsync();


        }

       

    }
}

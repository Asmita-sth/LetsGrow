using Letsgrow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letsgrow.Data.Repository
{
    public interface IGalleryRepository
    {
         Task<bool> AddPlantAsync(MPlant plant);
        Task<dynamic> GetAllPlantAsync();
    }
}

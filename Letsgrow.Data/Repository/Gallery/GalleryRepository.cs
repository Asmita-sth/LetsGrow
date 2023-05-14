using Letsgrow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letsgrow.Data.Repository
{
    public class GalleryRepository : IGalleryRepository
    {


        private ISqlDataAccess _db;
        public GalleryRepository(ISqlDataAccess db)
        {
            this._db = db;

        }


        public async Task<bool> AddPlantAsync(MPlant plant)
        {
            try
            {
                await this._db.SaveData("SPname", new { plant.Name, plant.Description, plant.Note});
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Task<dynamic> GetAllPlantAsync()
        {
            string query = "SpGetAllPlants";
            return this._db.GetData<string, dynamic>(query, new { });

        }

    }
}

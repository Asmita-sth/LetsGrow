using Letsgrow.Model;
using Microsoft.AspNetCore.Mvc;

namespace Letsgrow.Data.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private ISqlDataAccess _db;
        public UserRepository(ISqlDataAccess db)
        {
            _db = db;

        }


        public async Task<bool> AddAsync(MUser user)
        {
            try
            {
                await _db.SaveData("SPCreateUser", new { user.UserName, user.Email, user.Password });
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public Task<dynamic> GetAllAsync()
        {
            string query = "SpGetUser";
            return _db.GetData<string, dynamic>(query, new { });

        }


    }
}

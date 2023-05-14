using Letsgrow.Model;

namespace Letsgrow.Data.Repository.User
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(MUser user);
        Task<dynamic> GetAllAsync();
    }
}
using Letsgrow.Model;

namespace Letsgrow.Service
{
    public interface IUserService
    {

      Task<dynamic> GetAllUser();
      Task<dynamic> CreateUser(MUser user);


      string GetFileRepositoryPath();
    }
}
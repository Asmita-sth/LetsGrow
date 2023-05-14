using Letsgrow.Data.Repository.User;
using Letsgrow.Model;
using Microsoft.Extensions.Configuration;

namespace Letsgrow.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
   
            this._userRepository = userRepository;
            this._configuration = configuration;
        }
        public async Task<dynamic> GetAllUser()
        {

         return await _userRepository.GetAllAsync();
          

        }

        public async Task<dynamic> CreateUser(MUser user)
        {

            return await _userRepository.AddAsync(user);


        }


        public string GetFileRepositoryPath()
        {
            var repoPath = Path.GetFullPath(_configuration.GetSection("FileRepositoryPath").Value);
            repoPath = repoPath.Replace("\\", "/").Replace("//", "/");
            var hasEndingSlash = repoPath.LastIndexOf("/") == (repoPath.Length - 1);
            return hasEndingSlash ? repoPath : string.Format("{0}/", repoPath);
        }
    }
}

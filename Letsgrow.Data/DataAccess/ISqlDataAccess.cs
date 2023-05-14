using System.Threading.Tasks;

namespace Letsgrow.Data
{
    public interface ISqlDataAccess
    {

        Task<dynamic> GetData<T, P>(string spName, P parameters, string connectionId = "default");
        Task SaveData<T>(string spName, T parameters, string connectionId = "default");
    }
}
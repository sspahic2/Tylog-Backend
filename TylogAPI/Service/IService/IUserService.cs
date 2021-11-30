using Contract.Contract;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IUserService
    {
        Task<int> CreateUser(UserContract user);
        int UserExists(string username, string password);
        Task<UserContract> GetUserByID(int userID);
    }
}

using Contract.Contract;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IUserRepository
    {
        Task<int> CreateUser(UserContract user);
        Task<int> UserExists(string username, string password);
        Task<UserContract> GetUserByID(int userID);
    }
}

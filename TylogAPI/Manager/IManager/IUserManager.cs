using Contract.Contract;
using System.Threading.Tasks;

namespace Manager.IManager
{
    public interface IUserManager
    {
        int ValidateUser(string username, string password);
        Task<int> CreateUser(UserContract user);
    }
}

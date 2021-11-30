using Contract.Contract;
using Repository.IRepository;
using Service.IService;
using System.Threading.Tasks;

namespace Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> CreateUser(UserContract user)
        {
            return await _userRepository.CreateUser(user);
        }

        public async Task<UserContract> GetUserByID(int userID)
        {
            return await _userRepository.GetUserByID(userID);
        }

        public int UserExists(string username, string password)
        {
            return _userRepository.UserExists(username, password).Result;
        }
    }
}

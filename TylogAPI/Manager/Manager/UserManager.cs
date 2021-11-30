using Contract.Contract;
using Manager.IManager;
using Service.IService;
using System;
using System.Threading.Tasks;

namespace Manager.Manager
{
    public class UserManager: IUserManager
    {
        private readonly IUserService _userService;
        public UserManager(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<int> CreateUser(UserContract user)
        {
            if(ValidateUser(user.Username, user.Password) > 0)
            {
                return await _userService.CreateUser(user);
            }

            return -1;
        }

        public int ValidateUser(string username, string password)
        {
            if(!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                return _userService.UserExists(username, password);
            }
            return -1;
        }
    }
}

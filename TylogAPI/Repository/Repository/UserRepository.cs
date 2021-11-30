using Contract.Contract;
using Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private static List<UserDB> users = new List<UserDB>() { new UserDB { Username = "sspahic", Email = "sspahic@gmail.com", Password = "password", ID = 1} };
        public async Task<int> CreateUser(UserContract user)
        {
            int id = users.Select(x => x.ID).Max();
            users.Add(new UserDB { Username = user.Username, Password = user.Password, Email = user.Email, ID = id});
            return id;
        }

        public async Task<UserContract> GetUserByID(int userID)
        {
            var user = users.FirstOrDefault(x => x.ID == userID);

            return new UserContract() { Username = user.Username, Email = user.Email, Password = user.Password };
        }

        public async Task<int> UserExists(string username, string password)
        {
            var user = users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            return user != null ? user.ID : -1;
        }

    }

    class UserDB
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}

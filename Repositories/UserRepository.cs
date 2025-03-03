using System.Linq;
using System.Threading.Tasks;
using TourManagerment.Data;
using TourManagerment.Models;

namespace TourManagerment.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MTourContext _context;

        public UserRepository()
        {
            _context = new MTourContext();
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await Task.Run(() =>
            {
                return _context.Users.FirstOrDefault(u => u.UserName == userName);
            });
        }
    }
}

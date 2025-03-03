using System.Threading.Tasks;
using TourManagerment.Models;

namespace TourManagerment.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserNameAsync(string userName);
    }
}

using TourManagerment.Models;

namespace TourManagerment.Services
{
    public interface IAuthenService
    {
        Task<User> AuthenticateSynce(String userName, String password);
    }
}

using TourManagerment.Models;
using TourManagerment.Repositories;

namespace TourManagerment.Services
{
    class AuthenService : IAuthenService
    {
        private readonly IUserRepository _userRepository;
        public AuthenService()
        {
            _userRepository = new UserRepository();
        }
        async Task<User> IAuthenService.AuthenticateSynce(String userName, String password)
        {
            User user = await _userRepository.GetUserByUserNameAsync(userName);
            if (user == null || user.Password != password)
            {
                return null;
            }
            return user;
        }

    }
}

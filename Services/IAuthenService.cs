using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagerment.Models;

namespace TourManagerment.Services
{
    public interface IAuthenService
    {
        Task<User> AuthenticateSynce(String userName, String password);
    }
}

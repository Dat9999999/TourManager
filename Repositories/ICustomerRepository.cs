using TourManagerment.Models;

namespace TourManagerment.Repositories
{
    internal interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomersAsync();

    }
}

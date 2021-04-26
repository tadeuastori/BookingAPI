using BookingAPI.Domain.Entities;
using System.Threading.Tasks;

namespace BookingAPI.Domain.Interfaces.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        /// <summary>
        /// Get person by email
        /// </summary>
        /// <param name="email">Person Email</param>
        /// <returns>Person Entity</returns>
        Task<Person> GetByEmail(string email);
    }
}

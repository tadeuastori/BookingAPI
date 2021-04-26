using BookingAPI.Domain.Entities;
using System.Threading.Tasks;

namespace BookingAPI.Domain.Interfaces.Services
{
    public interface IPersonDomainService : IDomainServiceBase<Person>
    {
        Task<Person> GetPeopleAsync(string email);
    }
}

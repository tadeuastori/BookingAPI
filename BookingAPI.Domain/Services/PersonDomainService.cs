using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Interfaces.Repositories;
using BookingAPI.Domain.Interfaces.Services;
using BookingAPI.Domain.Services.Base;
using System.Threading.Tasks;

namespace BookingAPI.Domain.Services
{
    public class PersonDomainService : DomainServiceBase<Person>, IPersonDomainService
    {
        #region Attributes
        protected readonly IPersonRepository _repository; 
        #endregion

        #region Constructors
        public PersonDomainService(IPersonRepository repository) : base(repository)
        {
            _repository = repository;
        }
        #endregion

        #region Public Methods
        public async Task<Person> GetPeopleAsync(string email)
        {
            return await _repository.GetByEmail(email);
        }
        #endregion
    }
}

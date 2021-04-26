using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Interfaces.Repositories;
using BookingAPI.Infra.Data.Context;
using BookingAPI.Infra.Data.Repositories.Base;
using System.Threading.Tasks;

namespace BookingAPI.Infra.Data.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        #region Constructors
        public PersonRepository(BookingContext context) : base(context)
        {
        }
        #endregion

        #region Public Methods
        public async Task<Person> GetByEmail(string email)
        {
            return await GetFirstAsync(x => x.Email == email);
        }
        #endregion
    }
}

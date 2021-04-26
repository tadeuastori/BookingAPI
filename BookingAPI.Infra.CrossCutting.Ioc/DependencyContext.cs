using BookingAPI.Application.Interfaces;
using BookingAPI.Application.Services;
using BookingAPI.Domain.Interfaces.Repositories;
using BookingAPI.Domain.Interfaces.Services;
using BookingAPI.Domain.Services;
using BookingAPI.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookingAPI.Infra.CrossCutting.Ioc
{
    public class DependencyContext
    {
        public static void Register(IServiceCollection services)
        {
            //Application
            //services.AddScoped(typeof(IApplicationServiceBase<,>), typeof(ApplicationServiceBase<,>));
            services.AddScoped<IPersonApplicationService, PersonApplicationService>();
            services.AddScoped<IRoomApplicationService, RoomApplicationService>();
            services.AddScoped<IReservationApplicationService, ReservationApplicationService>();

            //Domain
            //services.AddScoped(typeof(IDomainServiceBase<>), typeof(DomainServiceBase<>));
            services.AddScoped<IPersonDomainService, PersonDomainService>();
            services.AddScoped<IRoomDomainService, RoomDomainService>();
            services.AddScoped<IReservationDomainService, ReservationDomainService>();

            //Repository
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
        }
    }
}

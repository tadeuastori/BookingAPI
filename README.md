# Booking API

API developed to booking hotel room scheduling. 

[![Generic badge](https://img.shields.io/badge/Made_with-.Net_5-blue.svg)](https://shields.io/)
[![Generic badge](https://img.shields.io/badge/Designer_Pattern-DDD-red.svg)](https://shields.io/)


## Executing the project

1. Go to ***..\BookingAPI\src\BookingAPI.Services.Api\appsettings.json*** file and set up the SQL Server ConnectionString;
2. In the ***Package Manager Console***, set up the ***Defaul Project*** to ***src\BookingAPI.Infra.Data\BookingAPI.Infra.Data***
3. In the ***Package Manager Console***, run Migration to create the database. ```update-database```
4. Set up the ***src\BookingAPI.Services.Api\BookingAPI.Services.Api*** as Startup Project.
5. Run the project.

## Usage

The project can be tested using the Swagger already added to the project.  
When running, a page will open in the browser where the created EndPoints will be available for testing.

## Used Technology
- .Net 5
- Entity Core
- Fluent Validation
- AutoMapper
- Dependency Injection

## Bussines Rules
> 1. All reservations start at least the next day of booking;
> 2. The stay can’t be longer than 3 days;
> 3. It can’t be reserved more than 30 days in advance;
> 4. To simplify, the API is insecure.


## References
> 1. [Overview about Booking System Rules](https://smallbusiness.co.uk/how-to-create-an-online-booking-system-2550306/)
> 2. [Informations about DDD pt1](https://medium.com/@ericandrade_24404/parte-01-criando-arquitetura-em-camadas-com-ddd-inje%C3%A7%C3%A3o-de-dep-ef-60b851c88461)
> 3. [Informations about DDD pt2](https://medium.com/@ericandrade_24404/parte-02-criando-arquitetura-em-camadas-com-ddd-inje%C3%A7%C3%A3o-de-dep-ef-defac0005667)
> 4. [Tips about how to configure relationships in Entity Core 5](https://www.michalbialecki.com/2020/10/02/how-to-configure-relationships-in-entity-framework-core-5/)


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)

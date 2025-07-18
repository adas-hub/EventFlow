# EventFlow

A scalable and maintainable .NET application for managing users, roles, events, and registrations. Built following Clean Architecture principles to ensure separation of concerns, testability, and maintainability.

## Features

- **User Management:** Register, authenticate, and manage users.  
- **Role Management:** Assign and remove roles (Admin, User, Organizer, Attendee).  
- **Event Management:** Create and manage events with participant registration.  
- **Registration:** Register and manage event participation.  
- **Authentication:** JWT-based authentication and role-based authorization.  
- **Error Handling:** Centralized and consistent error responses.  
- **API Documentation:** Integrated Swagger UI for easy API exploration.

## Technologies

- **.NET 8**  
- **ASP.NET Core Web API**  
- **Entity Framework Core**  
- **MediatR** (CQRS and request/response handling)  
- **JWT Authentication**  
- **SQL Server** (default, configurable)  
- **Swagger/OpenAPI**

## Architecture

This project follows **Clean Architecture** principles:

- **Domain:** Core business logic and entities.  
- **Application:** Use cases, commands, queries, and interfaces.  
- **Infrastructure:** Data access, external services, and persistence.  
- **API:** HTTP endpoints and middleware.

## Considerations & Future Improvements

- **Rich Domain Models:** Evolve domain entities to encapsulate more behavior and business rules rather than being simple data containers, enabling richer interactions within the domain layer. 
- **Caching:** Add caching layers to reduce database load for frequently accessed data like events and user roles.  
- **Security:** Harden security by adding refresh tokens, rate limiting, and audit logging.  
- **Testing:** Increase automated testing coverage, including integration and end-to-end tests.  
- **Docker & CI/CD:** Containerize the application and set up automated pipelines for building, testing, and deployment.

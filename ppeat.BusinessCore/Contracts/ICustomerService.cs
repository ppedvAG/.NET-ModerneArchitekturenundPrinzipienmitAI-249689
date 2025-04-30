using ppeat.Domain.Models;

namespace ppeat.BusinessCore.Contracts
{
    // Eigentlich ein Anti-Pattern und verstößt gegen das ISP: Interface Segregation Principle
    public interface ICustomerService : ICustomerQueryService, ICustomerCommandService
    {
    }

    public interface ICustomerCommandService
    {
        Task<Customer> RegisterCustomerAsync(string name, string email);
        Task UpdateCustomerDetailsAsync(Guid customerId, string name, string email);
    }

    public interface ICustomerQueryService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerWithMostCommentsAsync();
        Task<Customer?> GetCustomerWithMostReservationsAsync();
    }
}
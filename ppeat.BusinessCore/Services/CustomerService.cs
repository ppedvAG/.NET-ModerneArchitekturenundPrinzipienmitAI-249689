using Microsoft.EntityFrameworkCore;
using ppeat.BusinessCore.Contracts;
using ppeat.DataAccess.Data;
using ppeat.Domain.Models;

namespace ppeat.BusinessCore.Services;

public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _context;

    public CustomerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetCustomerWithMostCommentsAsync()
    {
        return await _context.Customers
            .Include(c => c.Comments)
            .OrderByDescending(c => c.Comments.Count)
            .FirstOrDefaultAsync();
    }

    public async Task<Customer?> GetCustomerWithMostReservationsAsync()
    {
        return await _context.Customers
            .Include(c => c.Reservations)
            .OrderByDescending(c => c.Reservations.Count)
            .FirstOrDefaultAsync();
    }

    public async Task<Customer> RegisterCustomerAsync(string name, string email)
    {
        var customer = new Customer
        {
            Name = name,
            Email = email,
            CreatedDate = DateTime.UtcNow,
            ChangedDate = DateTime.UtcNow
        };

        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task UpdateCustomerDetailsAsync(Guid customerId, string name, string email)
    {
        var customer = await _context.Customers.FindAsync(customerId);
        if (customer != null)
        {
            customer.Name = name;
            customer.Email = email;
            customer.ChangedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}

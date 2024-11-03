using AppShop.Domain.Entities;
using AppShop.Domain.Queries.Responses;
using AppShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AppShop.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;
    
    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Customer costumer)
    {
        _context.Customers.Add(costumer);
        await _context.SaveChangesAsync();
    }
    public async Task <FindCustomerByIdResponse> GetById(Guid customerId)
    {
        if (customerId == Guid.Empty)
        {
            throw new ArgumentException("Customer ID is invalid.");
        }
        
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);

        if (customer == null)
        {
            throw new KeyNotFoundException("Unable to locate the specified customer");
        }
        
        return new FindCustomerByIdResponse
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email
        };
    }
}
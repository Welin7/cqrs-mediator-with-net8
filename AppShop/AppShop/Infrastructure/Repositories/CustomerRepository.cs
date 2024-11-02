using AppShop.Domain.Entities;
using AppShop.Infrastructure.Data;

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
}
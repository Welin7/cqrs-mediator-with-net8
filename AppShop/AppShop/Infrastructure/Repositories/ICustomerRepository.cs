using AppShop.Domain.Entities;

namespace AppShop.Infrastructure.Repositories;

public interface ICustomerRepository
{
    Task Add(Customer costumer);
}
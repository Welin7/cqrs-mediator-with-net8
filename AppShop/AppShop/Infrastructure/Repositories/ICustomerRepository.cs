using AppShop.Domain.Entities;
using AppShop.Domain.Queries.Responses;

namespace AppShop.Infrastructure.Repositories;

public interface ICustomerRepository
{
    Task Add(Customer costumer);
    Task<FindCustomerByIdResponse> GetById(Guid customerId);
}
using AppShop.Domain.Commands.Requests;
using AppShop.Domain.Commands.Responses;

namespace AppShop.Domain.Handlers;

public interface ICreateCustomerHandler
{
    Task <CreateCustomerResponse> Handle(CreateCustomerRequest command);
}
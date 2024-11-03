using AppShop.Domain.Queries.Requests;
using AppShop.Domain.Queries.Responses;

namespace AppShop.Domain.Handlers;

public interface IFindCustomerByIdHandler
{
    Task <FindCustomerByIdResponse> Handle(FindCustomerByIdRequest command);
}
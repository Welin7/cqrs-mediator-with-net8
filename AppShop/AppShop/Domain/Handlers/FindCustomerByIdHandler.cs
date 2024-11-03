using AppShop.Domain.Queries.Requests;
using AppShop.Domain.Queries.Responses;
using AppShop.Infrastructure.Repositories;

namespace AppShop.Domain.Handlers;

public class FindCustomerByIdHandler : IFindCustomerByIdHandler
{
    private readonly ICustomerRepository _repository;

    public FindCustomerByIdHandler(ICustomerRepository repository)
    {
       _repository = repository;   
    }
    
    public async Task <FindCustomerByIdResponse> Handle(FindCustomerByIdRequest command)
    {
       var costumerLocated =  await _repository.GetById(command.Id);
       return costumerLocated;
    }
}
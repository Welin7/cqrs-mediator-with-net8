using AppShop.Domain.Commands.Requests;
using AppShop.Domain.Commands.Responses;
using AppShop.Domain.Entities;
using AppShop.Infrastructure.Repositories;

namespace AppShop.Domain.Handlers;

public class CreateCustomerHandler : ICreateCustomerHandler
{
    private readonly ICustomerRepository _repository;
    
    public CreateCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task <CreateCustomerResponse> Handle(CreateCustomerRequest command)
    {
        // Cria a entidade
        var customer = new Customer(command.Name, command.Email);

        // Persiste a entidade no banco
         await _repository.Add(customer);
        
        // Retorna a resposta
        return new CreateCustomerResponse
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            Date = DateTime.Now
        };
    }
}

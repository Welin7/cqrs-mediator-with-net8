using AppShop.Domain.Commands.Requests;
using AppShop.Domain.Handlers;
using AppShop.Domain.Queries.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AppShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICreateCustomerHandler _createCustomerHandler;
    private readonly IFindCustomerByIdHandler _findCustomerById;

    public CustomerController(ICreateCustomerHandler createCustomerHandler, IFindCustomerByIdHandler findCustomerById)
    {
        _createCustomerHandler = createCustomerHandler;
        _findCustomerById = findCustomerById;
    }
    
    [HttpPost("customers")]
    public async Task <IActionResult> Create([FromBody]CreateCustomerRequest command)
    {
        var response = await _createCustomerHandler.Handle(command);
        return Ok(response);
    }
    
    [HttpGet("{costumerId}")]
    public async Task <IActionResult> GetById(Guid costumerId)
    {
        try
        {
            var command = new FindCustomerByIdRequest { Id = costumerId };
            var response = await _findCustomerById.Handle(command);
            return Ok(response);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Customer not found.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
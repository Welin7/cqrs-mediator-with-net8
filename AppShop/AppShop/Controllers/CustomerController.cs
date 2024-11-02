using AppShop.Domain.Commands.Requests;
using AppShop.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace AppShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICreateCustomerHandler _createCustomerHandler;

    public CustomerController(ICreateCustomerHandler createCustomerHandler)
    {
        _createCustomerHandler = createCustomerHandler;         
    }
    
    [HttpPost("customers")]
    public async Task <IActionResult> Create([FromBody]CreateCustomerRequest command)
    {
        var response = await _createCustomerHandler.Handle(command);
        return Ok(response);
    }
}
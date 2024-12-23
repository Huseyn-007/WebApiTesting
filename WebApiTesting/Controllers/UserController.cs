using Microsoft.AspNetCore.Mvc;
using WebApiTesting.Business.Services.Abstracts;
using WebApiTesting.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTesting.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    // GET: api/<UserController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    // GET api/<UserController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        return await _service.GetByIdAsync(id);
    }

    // POST api/<UserController>
    [HttpPost]
    public async Task Post([FromBody] User user)
    {
        await _service.AddAsync(user);
    }

    // PUT api/<UserController>/5
    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] User user)
    {
        await _service.UpdateAsync(user);
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        var item = await _service.GetByIdAsync(id);
        await _service.DeleteAsync(item);
    }
}

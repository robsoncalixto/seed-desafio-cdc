using Microsoft.AspNetCore.Mvc;

namespace seed_desafio_cdc.API;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromServices] IAuthorRepository repository, [FromBody] AuthorInput input)
    {
           return Ok(await repository.SaveAsync(input.toModel()));
    }

    [HttpGet]
    public async Task<IActionResult> List([FromServices] IAuthorRepository repository ){
        return Ok(await repository.ListAsync());
    }
}

using Microsoft.AspNetCore.Mvc;


namespace seed_desafio_cdc.API;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromServices] ICategoryRepository repository, [FromBody] CategoryInput input)
    {
        var categoryExisting = await repository.FindByNameAsync(input.name);
        
        if (categoryExisting != null){            
            ModelState.AddModelError("Name","Category already exists.");
            return  BadRequest(ModelState);
        } 
        var category = await repository.SaveAsync(input.ToModel());
        return Ok(category);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromServices] ICategoryRepository repository)
    {
        var categories = await repository.FindAllAsync();
        return Ok(categories);
    }    
}

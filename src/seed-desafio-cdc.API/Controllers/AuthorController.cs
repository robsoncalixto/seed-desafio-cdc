﻿using Microsoft.AspNetCore.Mvc;

namespace seed_desafio_cdc.API;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorRepository repository;

    public AuthorController(IAuthorRepository repository)
    {
        this.repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AuthorInput input)
    {   
        var emailExisting = await repository.FindByEmailAsync(input.emailAddress!);        
        if(emailExisting != null){
            ModelState.AddModelError("Email", "Email already exists.");
            return  BadRequest(ModelState);
        }       
        return Ok(await repository.SaveAsync(input.toModel()));
    }

    [HttpGet]
    public async Task<IActionResult> List(){
        return Ok(await repository.ListAsync());
    }
}

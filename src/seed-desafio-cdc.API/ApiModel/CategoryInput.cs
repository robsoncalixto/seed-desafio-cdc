﻿using System.ComponentModel.DataAnnotations;

namespace seed_desafio_cdc.API;

public class CategoryInput
{
    [Required(AllowEmptyStrings = false)]
    [UniqueValue("name", typeof(Category))]
    public string? name { get; set; }

    public CategoryInput(string? name)
    {
        this.name = name;
    }

    public Category ToModel()
    {
        return new Category(name);
    }
}

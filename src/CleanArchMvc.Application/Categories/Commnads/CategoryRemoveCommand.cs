﻿namespace CleanArchMvc.Application.Categories.Commnads;

public class CategoryRemoveCommand : CategoryCommand
{
    public int Id { get; set; }
	public CategoryRemoveCommand(int id) => Id = id;
}

using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Services._Category;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService) => _categoryService = categoryService;

    [HttpGet]
    public async Task<ActionResult> Index() => View(await _categoryService.GetCategoriesAsync());

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<ActionResult> Create(CategoryDTO category)
    {
        if(!ModelState.IsValid)
            return View(category);

        await _categoryService.CreateAsync(category);
        return RedirectToAction(nameof(Index));
    }
}

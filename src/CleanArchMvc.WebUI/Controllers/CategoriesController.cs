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

    [HttpGet]
    public async Task<ActionResult> Edit(int? id)
    {
        if (id is null) return NotFound();

        var categoryVM = await _categoryService.GetByIdAsync(id);

        if (categoryVM is null) return NotFound();

        return View(categoryVM);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(CategoryDTO category)
    {
        if (!ModelState.IsValid) return View(category);

        await _categoryService.UpdateAsync(category);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<ActionResult> Delete(int? id)
    {
        if (id is null) return NotFound();

        var category = await _categoryService.GetByIdAsync(id);

        if (category is null) return NotFound();

        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        await _categoryService.RemoveAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<ActionResult> Details(int? id)
    {
        if (id is null) return NotFound();

        var category = await _categoryService.GetByIdAsync(id);

        if (category is null) return NotFound();

        return View(category);
    }
}

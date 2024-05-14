﻿using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Services._Category;
using CleanArchMvc.Application.Services._Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductsController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult> Index() => View(await _productService.GetProductsAsync());

    [HttpGet]
    public async Task<ActionResult> Create()
    {
        ViewBag.CategoryId = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name");
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(ProductDTO product)
    {
        if (!ModelState.IsValid) return View(product);

        await _productService.CreateAsync(product);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<ActionResult> Edit(int? id)
    {
        if (id is null) return NotFound();

        var product = await _productService.GetByIdAsync(id);

        if (product is null) return NotFound();

        ViewBag.CategoryId = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name", product.CategoryId);

        return View(product);
    }
}

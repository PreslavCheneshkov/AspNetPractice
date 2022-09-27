﻿using Microsoft.AspNetCore.Mvc;
using StamoFirstDemo.Core.Contracts;

namespace StamoFirstDemo.Controllers
{
    /// <summary>
    /// Web shop products
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// List all products
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAll();
            ViewData["Title"] = "Products";

            return View(products);
        }
    }
}

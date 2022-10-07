using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StamoFirstDemo.Core.Contracts;
using StamoFirstDemo.Core.Data;
using StamoFirstDemo.Core.Data.Models;
using StamoFirstDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamoFirstDemo.Core.Services
{
    /// <summary>
    /// Manipulates product data
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration config;
        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="_config">Application configuration</param>
        public ProductService(IConfiguration _config, ApplicationDbContext _context)
        {
            context = _context;
            config = _config;
        }
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return await context.Products
                .Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                }).ToListAsync();
        }

        public async Task Add(ProductDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }
    }
}

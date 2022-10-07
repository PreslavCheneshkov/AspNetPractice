using StamoFirstDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamoFirstDemo.Core.Contracts
{
    /// <summary>
    /// Manipulates product data
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        Task<IEnumerable<ProductDto>> GetAll();
        Task Add(ProductDto productDto);
    }
}

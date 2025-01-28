using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductBrandRepository : IProductBrandRepository
    {
        private readonly StoreContext _context;
        public ProductBrandRepository(StoreContext context) {
            _context = context;
        }
        public async Task<ProductBrand> GetProductBrandByIdAsync(int id)
        {
            var productBrand = await _context.ProductBrands.FindAsync(id);
            if (productBrand==null) { 
                throw new KeyNotFoundException($"Product with ID {id} was not found.");
            };
            return productBrand;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsByAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }
    }
}
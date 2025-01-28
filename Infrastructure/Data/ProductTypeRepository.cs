using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly StoreContext _context;
        public ProductTypeRepository(StoreContext context) 
        {
            _context = context;
        }

        public async Task<ProductType> GetProductTypeByIdAsync(int id)
        {
            var product = await _context.ProductTypes.FindAsync(id);

            if (product == null) { 
                throw new KeyNotFoundException($"Product with ID {id} was not found.");
            }
            return product;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }

}
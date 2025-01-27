using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductBrandRepository
    {
        Task<ProductBrand> GetProductBrandByIdAsync(int id);

        Task<IReadOnlyList<ProductBrand>> GetProductBrandsByAsync(); 
    }
}
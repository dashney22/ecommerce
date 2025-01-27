using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsBrandController : ControllerBase
    {
        private readonly IProductBrandRepository _productBrandRepository;

        public ProductsBrandController(IProductBrandRepository productBrandRepository) {
            _productBrandRepository = productBrandRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands() {
            var productBrands = await _productBrandRepository.GetProductBrandsByAsync();
            if (productBrands == null) {
                return NotFound();
            }
            return Ok(productBrands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductBrandById(int id){
            var productBrand = await _productBrandRepository.GetProductBrandByIdAsync(id);
            if (productBrand == null) {
                return NotFound();
            }
            return Ok(productBrand);
        }



    }
}
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
    public class ProductTypeController: ControllerBase
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeController(IProductTypeRepository productTypeRepository) {
            _productTypeRepository = productTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes() {
            var productTypes = await _productTypeRepository.GetProductTypesAsync();
            if (productTypes == null) {
                return NotFound();
            }
            return Ok(productTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> GetProductTypeById(int id) {

            var productType = await _productTypeRepository.GetProductTypeByIdAsync(id);
            if (productType == null) {
                return NotFound();
            }
            return Ok(productType);
        }


    }
}
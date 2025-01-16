using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() {
            // ToListAsync() makes the procedure to be asynchronous!!!
            // ToList() leaves it synchronous and might create query backlog
            var products = await _repository.GetProductsAsync();

            if (products == null) { 
                return NotFound();
            }
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) {
            var product = await _repository.GetProductByIdAsync(id);

            // One can use FindAsync() or SingleOrDeafultAsync(x=>x.Id=id)
            if (product == null)
            {
                return NotFound(); // Returns a 404 Not Found if no product is found
            }
            return Ok(product); // Else part
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() {
            // ToListAsync() makes the procedure to be asynchronous!!!
            // ToList() leaves it synchronous and might create query backlog
            var products = await _context.Products.ToListAsync();

            if (products == null) { 
                return NotFound();
            }
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) {
            var product = await _context.Products.FindAsync(id);

            // One can use FindAsync() or SingleOrDeafultAsync(x=>x.Id=id)
            if (product == null)
            {
                return NotFound(); // Returns a 404 Not Found if no product is found
            }
            return Ok(product); // Else part
        }
    }
}
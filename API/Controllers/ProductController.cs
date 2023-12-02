using API.Data;
using API.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
 
    public class ProductController :BasiAPIContoller
    {
        private readonly StoreContext context;
        public ProductController(StoreContext context)
        {
            this.context= context;  
        }

        [HttpGet]

        public async Task<ActionResult<List<Product>>> Getproduct()
        {
            return  await context.Products.ToListAsync();

           
        }

        [HttpGet("{id}")] 

        public  async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product =  context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        
    }
}
using Crafts.Models;
using Crafts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crafts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JasonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JasonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string productId, 
                                [FromQuery] int rating)
        {
            ProductService.AddRating(productId, rating);
            return Ok();  
        }
    }
}

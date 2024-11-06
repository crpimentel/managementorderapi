using managementorderapi.Helper;
using managementorderapi.Models;
using managementorderapi.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace managementorderapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryProduct _productRepository;


        public ProductController(IRepositoryProduct productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET: api/Client
        [HttpGet("getProducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {

                var products = await _productRepository.GetAll();
                return Ok(products); // 200 OK

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error buscando los productos: {ex.Message}"); // 500 Internal Server Error
            }
        }
        [HttpGet("getProductsByFilter")]
        public async Task<IActionResult> GetProductsByFilter([FromQuery] ProductBindProperty product)
        {
            try
            {
                var products = await _productRepository.FilterProductsAsync(product.id, product.name, product.stock, product.price, product.description);
                if (products == null || products.Count() == 0)
                {
                    return NotFound($"No se encontró ningún producto con las especificaciones: " +
                           $"ID: {product.id?.ToString() ?? "N/A"}, " +
                           $"Nombre: {product.name ?? "N/A"}, " +
                           $"Stock: {product.stock?.ToString() ?? "N/A"}, " +
                           $"Precio: {product.price}, " +
                           $"Descripción: {product.description ?? "N/A"}"); 
                    // 404 Not Found
                }
                return Ok(products); // 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error buscando los productos: {ex.Message}"); // 500 Internal Server Error
            }
        }

    }
}

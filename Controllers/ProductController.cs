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
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
               
                var products = await _productRepository.GetAll();
                return Ok(products); // 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving clients: {ex.Message}"); // 500 Internal Server Error
            }
        }
    }
}

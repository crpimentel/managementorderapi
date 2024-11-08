using managementorderapi.Data;
using managementorderapi.Helper;
using managementorderapi.Models;
using managementorderapi.Repositories;
using managementorderapi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace managementorderapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryProduct _productRepository;
        private readonly AppDbContext _context;

        public ProductController(IRepositoryProduct productRepository, AppDbContext context)
        {
            _productRepository = productRepository;
            _context = context;
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

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ProductCreateDto productDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new ApiResponse<object>
                {
                    Code = HttpStatusCode.BadRequest.ToString(),
                    Success = false,
                    Message = "Validation failed",
                    Errors = errors
                });
            }
            
            try
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                // Validate price and stock values if necessary
                if (productDto.Price < 1 || productDto.Stock < 1)
                {
                    return BadRequest(new ApiResponse<object>
                    {
                        Code = HttpStatusCode.BadRequest.ToString(),
                        Success = false,
                        Message = "Precio y cantidad deben ser mayor a cero"
                    });
                }
                // Create and save the Product entity
                var product = new Product
                {
                    Name = productDto.Name,
                    Description = productDto.Description,
                    Price = productDto.Price,
                    Stock = productDto.Stock,
                };
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                if (productDto.Images != null && productDto.Images.Any())
                {
                    foreach (var formFile in productDto.Images)
                    {
                        if (formFile.Length > 0)
                        {
                            await using var memoryStream = new MemoryStream();
                            await formFile.CopyToAsync(memoryStream);

                            var productImage = new ProductImage
                            {
                                ImageData = memoryStream.ToArray(),
                                ImageType = formFile.ContentType,
                                ProductId = product.Id 
                            };

                            _context.ProductImages.Add(productImage);
                        }
                    }

                    await _context.SaveChangesAsync(); 
                }
                await transaction.CommitAsync();

                return Ok(new ApiResponse<object>
                {
                    Code = HttpStatusCode.OK.ToString(),
                    Success = true,
                    Message = "Product creado exitosamente!",
                    Data = new
                    {
                        product.Id,
                        product.Name,
                        product.Description,
                        product.Price,
                        product.Stock
                    }
                });
            }
            catch (Exception ex)
            {
                // Respond with a 500 Internal Server Error and a meaningful message
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = "An internal server error occurred. Please try again later.",
                    Errors = new List<string> { ex.Message }
                });
            }
        }
    }
}

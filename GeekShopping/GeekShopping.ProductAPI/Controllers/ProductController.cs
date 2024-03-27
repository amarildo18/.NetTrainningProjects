using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository= repository?? throw new ArgumentNullException(nameof(repository));
        }

        // GET: api/v1/Product
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>A list of Products</returns>
        /// <response code="200">Returns a list of Products</response>
        /// <response code="404">If there are no Products</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> GetAll()
        {
            var products = await _repository.FindAll();
            return Ok(products);
        }

        // GET: api/v1/Product/id
        /// <summary>
        /// Gets specific product by it´s Id
        /// </summary>
        /// <returns>A list of Products</returns>
        /// <response code="200">Returns a Product</response>
        /// <response code="404">If there are no Productrelated to given Id</response>
        [HttpGet("{id}", Name ="GetProductById")]
        public async Task<ActionResult<ProductVO>> GetById(long id)
        {
            var product = await _repository.FindById(id);
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO vo)
        {
            if(vo == null)
            {
                return BadRequest();
            }
            else
            {
                var product = await _repository.Create(vo);
                return Ok(product);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO vo)
        {
            if (vo == null)
            {
                return BadRequest();
            }
            else
            {
                var product = await _repository.Update(vo);
                return Ok(product);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (status == null)
            {
                return NotFound();
            }

            return Ok(status);
        }
    }
}

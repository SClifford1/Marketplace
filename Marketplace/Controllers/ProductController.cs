using System.Collections.Generic;
using Marketplace.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Marketplace.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    [ValidationActionFilter]
    public class ProductController : ControllerBase
    {
        private readonly IProductService m_service;

        public ProductController(IProductService _service)
        {
            m_service = _service;
        }

        /// <summary>
        /// Get all products in the marketplace
        /// </summary>
        /// <returns>A collection of products</returns>
        /// <response code="200">The complete collection of products</response>     
        // GET api/products
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("/v1/products")]
        public ActionResult<IList<Product>> GetAll()
        {
            return Ok(m_service.GetAll());
        }

        /// <summary>
        /// Get a specific product by product id
        /// </summary>
        /// <param name="_id">The id of the product</param>
        /// <returns>The requested product</returns>
        /// <response code="200">Returns the product that was requested</response>     
        /// <response code="404">The requested product wasn't found</response>   
        // GET api/product/{_id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{_id}")]
        public IActionResult Get(int _id)
        {
            var product = m_service.Get(_id);
            return (product != null) ? Ok(product) : NotFound() as IActionResult;
        }

        /// <summary>
        /// Adds a new product to the marketplace
        /// </summary>
        /// <param name="_product">The product data - The ID is ignored</param>
        /// <response code="200">The product was created successfully</response>     
        /// <response code="400">The product to insert includes some invalid data</response>     
        // POST api/product   
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Post([FromForm] Product _product)
        {
            return m_service.Add(_product) ? Ok() : Conflict() as IActionResult;
        }

        /// <summary>
        /// Updates the targeted product in the marketplace
        /// </summary>
        /// <param name="_id">The id of the product</param>
        /// <param name="_product">The product changes</param>
        /// <response code="200">The product was updated successfully</response>     
        /// <response code="400">The product update includes some invalid data</response>   
        // PUT api/product
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{_id}")]
        public IActionResult Put(int _id, [FromForm] Product _product)
        {
            return m_service.Update(_id, _product) ? Ok() : NotFound(_id) as IActionResult;
        }

        /// <summary>
        /// Deletes the targeted product
        /// </summary>
        /// <param name="_id">The id of the product</param>
        /// <response code="200">The product was deleted successfully</response>     
        /// <response code="404">The product to delete wasn't found</response>   
        // DELETE api/product/{_id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{_id}")]
        public IActionResult Delete(int _id)
        {
            return m_service.Delete(_id) ? Ok() : NotFound(_id) as IActionResult;
        }
    }
}

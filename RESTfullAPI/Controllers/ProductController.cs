using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfullAPI.Infrastructure.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

#pragma warning disable CS8632

namespace RestfullAPI.Controllers
{
    /// <summary>
    /// Classe de Controladores de Produtos
    /// </summary>

    //api/<ProductController>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Método GET que devolve todos os produtos atualmente activos
        /// </summary>
        /// <returns></returns>

        [SwaggerOperation("Get all active products", null, Tags = new[] { "3. Products" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(List<ProductDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        // GET: api/<ProductController>/GetAllActive
        [HttpGet("GetAllActiveProducts")]
        public async Task<ActionResult<List<ProductDTO>>> GetAllActive()
        {
            return Ok(await _productService.GetAllActive());
        }

        /// <summary>
        /// Método GET que devolve todos os produtos na DB
        /// </summary>
        /// <returns></returns>


        [SwaggerOperation("Get all products", null, Tags = new[] { "3. Products" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(List<ProductDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        //GET: api/<ProductController>/GetAll
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<ProductDTO>>> GetAll()
        {
            return Ok(await _productService.GetAll());

        }

        /// <summary>
        /// Método GET que devolve determinado produto por Id ou nome
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>

        [SwaggerOperation("Get product by id or name", null, Tags = new[] { "3. Products" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(ProductDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        // GET api/<ProductController>/{id}
        [HttpGet("GetProductByIdOrName")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdOrName(int? id, string? name)
        {
            return Ok(await _productService.GetProductDTOAsync(id, name));

        }

        /// <summary>
        /// Método POST que adiciona um novo produto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>


        [SwaggerOperation("Add a product", null, Tags = new[] { "3. Products" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        // POST api/<ProductController>/AddProduct
        [HttpPost("AddProduct")]
        public async Task<ActionResult<bool>> AddProduct([FromBody] ProductDTO product)
        {
            var result = await _productService.AddProduct(product);

            if (result == false) { return BadRequest(new { message = "Product already exist with that name." }); }

            else { return Ok(new { message = "Product successfully created." }); }

        }

        /// <summary>
        /// Método PUT que atualiza um produto já existente
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>

        [SwaggerOperation("Update a product", null, Tags = new[] { "3. Products" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        // PUT api/<ProductController>/UpdateProduct
        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<bool>> UpdateProduct([FromBody] ProductDTO product)
        {
            var result = await _productService.UpdateProduct(product);

            if (result == false) { return BadRequest(new { message = "Product doesn't exist" }); }

            else { return Ok(new { message = "Product successfully updated." }); }


        }

        /// <summary>
        /// Método DELETE que apaga produtos já existentes
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerOperation("Remove a product", null, Tags = new[] { "3. Products" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        // DELETE api/<ProductController>/RemoveProduct
        [HttpPut("RemoveProduct")]
        public async Task<ActionResult<bool>> RemoveProduct(string? name, int? id)
        {
            var result = await _productService.RemoveProduct(id, name);

            if (result == false) { return BadRequest(new { message = "Product doesn't exist" }); }

            else { return Ok(new { message = "Product successfully removed." }); }
        }
    }
}

using BusinessLayer;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IService<Product> _product;

        public ProductsController(IService<Product> prd)
        {
            //_product = new Manager<Product>();
            _product = prd;
        }
        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_product.GetAll());
        }

        /// <summary>
        /// Get Products By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_product.GetByID(id));
        }

        /// <summary>
        /// Create Products
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [Authorize("admin")]
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            return Ok(_product.Create(product));
        }

        /// <summary>
        /// Update Products  
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Authorize("admin")]
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            return Ok(_product.Update(product));
        }

        /// <summary>
        /// Delete Products
        /// </summary>
        /// <param name="id"></param>
        [Authorize("admin")]
        [HttpDelete]
        public void Delete(int id)
        {
            _product.Delete(id);
        }
    }
}

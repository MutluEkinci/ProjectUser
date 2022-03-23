using BusinessLayer;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IService<Product> _product;

        public ProductController()
        {
            _product = new Manager<Product>();
        }
        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Product> Get()
        {
            return _product.GetAll();
        }

        /// <summary>
        /// Get Products By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _product.GetByID(id);
        }

        /// <summary>
        /// Create Products
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            return _product.Create(product);
        }

        /// <summary>
        /// Update Products  
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public Product Put([FromBody] Product product)
        {
            return _product.Update(product);
        }

        /// <summary>
        /// Delete Products
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void Delete(int id)
        {
            _product.Delete(id);
        }
    }
}

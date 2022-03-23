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
    public class UserController : ControllerBase
    {
        private IService<User> _user;

        public UserController()
        {
            _user = new Manager<User>();
        }
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<User> Get()
        {
            return _user.GetAll();
        }

        /// <summary>
        /// Get Users By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _user.GetByID(id);
        }

        /// <summary>
        /// Create Users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public User Post([FromBody] User user)
        {
            return _user.Create(user);
        }

        /// <summary>
        /// Update Users  
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public User Put([FromBody] User user)
        {
            return _user.Update(user);
        }

        /// <summary>
        /// Delete Users
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void Delete(int id)
        {
            _user.Delete(id);
        }
    }
}

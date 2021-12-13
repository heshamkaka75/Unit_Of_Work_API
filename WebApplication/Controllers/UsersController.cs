using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.IRepository;
using WebApplication.Models;
using WebApplication.Repository;
using WebApplication.UnitOfWorks;


namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await unitOfWork.Users.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await unitOfWork.Users.GetByIdAsync(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            await unitOfWork.Users.AddAsync(user);
            return Ok();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(User user)
        {
            await unitOfWork.Users.UpdateAsync(user);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(User user)
        {
            await unitOfWork.Users.DeleteAsync(user);
            return NoContent();
        }
    }
}

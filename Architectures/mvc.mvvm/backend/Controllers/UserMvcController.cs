using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Database.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("mvc/user")]
    public class UserMvcController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserMvcController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<Guid> CreateUser([FromBody] User user)
        {
            return await _userRepository.Add(user);
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<User> GetUserById([FromRoute] Guid id)
        {
            return await _userRepository.GetById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] User user)
        {
            var record = await _userRepository.GetById(id);

            record.Name = user.Name;
            record.Email = user.Email;
            record.Password = user.Password;

            _userRepository.Update(record);

            return Ok();    
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var record = await _userRepository.GetById(id);
            
            _userRepository.Remove(record);

            return Ok();
        }
    }
}


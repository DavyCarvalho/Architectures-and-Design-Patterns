using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Database.Interfaces;
using backend.Models;
using backend.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("mvvm/user")]
    public class UserMvvmController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserMvvmController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<Guid> CreateUser([FromBody] User user)
        {
            return await _userRepository.Add(user);
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            var users = await _userRepository.GetAll();
            var usersViewModels = users.Select(x => x.ToViewModel());

            return usersViewModels;
        }

        [HttpGet("{id}")]
        public async Task<UserViewModel> GetUserById([FromRoute] Guid id)
        {
            var user = await _userRepository.GetById(id);

            return user.ToViewModel();
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


using System;
using backend.ViewModel;

namespace backend.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserViewModel ToViewModel() {
        return new ()
            {
                Name = this.Name,
                Email = this.Email
            };
        } 
    }
}
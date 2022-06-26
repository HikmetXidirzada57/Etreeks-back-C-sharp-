using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RegisterDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName{ get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="The password and confirmation password do not same")]
        public string Password { get; set; } = null!;

        public string ConfirmPassword { get; set; } = null!;
    }
}

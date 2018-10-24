using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Presentation.Api.Models
{
    public class RegisterUserModel
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }

        public string Password { get; set; }
        public PlatformType PlatformType { get; set; }
    }
}
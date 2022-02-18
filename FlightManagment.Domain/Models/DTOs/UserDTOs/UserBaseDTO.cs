using System.ComponentModel.DataAnnotations;

namespace FlightManagment.Domain.Models.DTOs.UserDTOs
{
    public abstract class UserBaseDTO
    {
        // Email is UserName, and both properties are of type email
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

using JWTExampleApi.Entitties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTExampleApi.DTOs
{
    public class UserDTO
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? UserName { get; set; }

        [Required]
        [MaxLength(100)]
         public string? Password { get; set; }


        [Required]

        public string RoleName { get; set; }

        public int? MyProperty { get; set; }
    }
}

//Automapper configuration

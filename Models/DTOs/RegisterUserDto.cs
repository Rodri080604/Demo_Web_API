using System.ComponentModel.DataAnnotations;

namespace Demo_Web_API.Models.DTOs
{
    /*
    public class RegisterUserDto
    {


        [Required, MaxLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }


    public class UpdateUserDto
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string UserName { get; set; } = string.Empty;
    }
    public class UpdateEmailUserDto
    {
        [Required]
        public int Id { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }
    */
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
    public class RegisterUserDto
    {
        [Required, MaxLength(100)]
        public string UserName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }

    public class UpdateUserDto
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string UserName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; }

        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string? Password { get; set; }
    }
    public class UpdateEmailUserDto
    {
        [Required]
        public int Id { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}

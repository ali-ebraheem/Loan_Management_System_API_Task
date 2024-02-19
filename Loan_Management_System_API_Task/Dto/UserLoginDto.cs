using System.ComponentModel.DataAnnotations;

namespace Loan_Management_System_API_Task.Dto;

public class UserLoginDto
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}
using System.ComponentModel.DataAnnotations;
using Loan_Management_System_API_Task.Enum;

namespace Loan_Management_System_API_Task.Dto;

public class LoanApplicationDto
{
    [Required] public int Id { get; set; }
    [Required] public int UserId { get; set; }
    [Required] public decimal AmountRequested { get; set; }
    public string Purpose { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Loan_Management_System_API_Task.Dto;

public class LoanRepaymentDto
{
    [Required] public int Id { get; set; }
    [Required] public int LoanApplicationId { get; set; }
    [Required] public int UserId { get; set; }
    [Required] [Range(100, 1000000)] public decimal AmountPaid { get; set; }
}
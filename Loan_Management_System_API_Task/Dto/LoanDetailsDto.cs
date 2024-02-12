using Loan_Management_System_API_Task.Models;

namespace Loan_Management_System_API_Task.Dto;

public class LoanDetailsDto
{
    public int Id { get; set; }
    public int LoanApplicationId { get; set; }
    public int UserId { get; set; }
    public LoanApplication LoanApplication { get; set; }
    public User User { get; set; }
}
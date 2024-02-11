using Loan_Management_System_API_Task.Enum;

namespace Loan_Management_System_API_Task.Models;

public class LoanApplication
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal AmountRequested { get; set; }
    public DateTime ApplicationDate { get; set; }
    public string Purpose { get; set; }
    public LoanStatus Status { get; set; } // Pending, Approved, Rejected
    public User User { get; set; }
}
namespace Loan_Management_System_API_Task.Models;

public class LoanRepayment
{
    public int Id { get; set; }
    public int LoanApplicationId { get; set; }
    public int UserId { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; }

    // Navigation properties
    public LoanApplication LoanApplication { get; set; }
    public User User { get; set; }
}
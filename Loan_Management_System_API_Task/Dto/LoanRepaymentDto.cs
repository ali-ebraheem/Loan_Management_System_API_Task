namespace Loan_Management_System_API_Task.Dto;

public class LoanRepaymentDto
{
    public int LoanApplicationId { get; set; }
    public int UserId { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; }
}
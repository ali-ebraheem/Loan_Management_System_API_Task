namespace Loan_Management_System_API_Task.Dto;

public class LoanApplicationDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal AmountRequested { get; set; }
    public DateTime ApplicationDate { get; set; }
    public string Purpose { get; set; }
}
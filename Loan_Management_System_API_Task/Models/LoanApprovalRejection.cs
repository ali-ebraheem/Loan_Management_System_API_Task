using Loan_Management_System_API_Task.Enum;

namespace Loan_Management_System_API_Task.Models;

public class LoanApprovalRejection
{
    public int Id { get; set; }
    public int LoanApplicationId { get; set; }
    public int ApproverId { get; set; }
    public LoanStatus Status { get; set; } // Approval or Rejection
    public DateTime ApprovalRejectionDate { get; set; }

    // Navigation properties
    public LoanApplication LoanApplication { get; set; }
    public User Approver { get; set; }
}
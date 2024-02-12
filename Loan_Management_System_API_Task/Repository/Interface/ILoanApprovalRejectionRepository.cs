using Loan_Management_System_API_Task.Models;

namespace Loan_Management_System_API_Task.Repository.Interface;

public interface ILoanApprovalRejectionRepository
{
    ICollection<LoanApprovalRejection> GetAllLoanApprovalRejections();
    LoanApprovalRejection GetLoanApprovalRejectionById(int id);
    bool AddLoanApprovalRejection(LoanApprovalRejection loanApprovalRejection);
    bool UpdateLoanApprovalRejection(LoanApprovalRejection loanApprovalRejection);
    bool DeleteLoanApprovalRejection(int id);
    bool Save();
    
}
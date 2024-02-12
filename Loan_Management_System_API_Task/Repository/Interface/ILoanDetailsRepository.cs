using Loan_Management_System_API_Task.Models;

namespace Loan_Management_System_API_Task.Repository.Interface;

public interface ILoanDetailsRepository
{
    ICollection<LoanDetails> GetLoanDetails();
    LoanDetails GetLoanDetails(int id);
    bool AddLoanDetails(LoanDetails loanDetails);
    bool UpdateLoanDetails(LoanDetails loanDetails);
    bool DeleteLoanDetails(int id);
    bool Save();
    
}
using Loan_Management_System_API_Task.Models;

namespace Loan_Management_System_API_Task.Repository.Interface;

public interface ILoanRepaymentRepository
{
    ICollection<LoanRepayment> GetAllLoanRepayments();
    LoanRepayment GetLoanRepaymentById(int id);
    bool AddLoanRepayment(LoanRepayment loanRepayment);
    bool UpdateLoanRepayment(LoanRepayment loanRepayment);
    bool DeleteLoanRepayment(int id);
    bool Save();
    
}
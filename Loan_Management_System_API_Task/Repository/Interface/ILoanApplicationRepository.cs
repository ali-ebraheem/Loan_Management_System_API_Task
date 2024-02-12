using Loan_Management_System_API_Task.Models;

namespace Loan_Management_System_API_Task.Repository.Interface;

public interface ILoanApplicationRepository
{
    ICollection<LoanApplication> GetLoanApplications();
    LoanApplication GetLoanApplication(int id);
    bool AddLoanApplication(LoanApplication loanApplication);
    bool UpdateLoanApplication(LoanApplication loanApplication);
    bool DeleteLoanApplication(int id);
    bool Save();

}
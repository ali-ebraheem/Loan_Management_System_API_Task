using Loan_Management_System_API_Task.Data;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Repository.Interface;

namespace Loan_Management_System_API_Task.Repository.Implementation;

public class LoanApplicationRepository(DataContext context): ILoanApplicationRepository
{
    public ICollection<LoanApplication> GetLoanApplications()
    {
        throw new NotImplementedException();
    }

    public LoanApplication GetLoanApplication(int id)
    {
        throw new NotImplementedException();
    }

    public bool AddLoanApplication(LoanApplication loanApplication)
    {
        throw new NotImplementedException();
    }

    public bool UpdateLoanApplication(LoanApplication loanApplication)
    {
        throw new NotImplementedException();
    }

    public bool DeleteLoanApplication(int id)
    {
        throw new NotImplementedException();
    }

    public bool Save()
    {
        throw new NotImplementedException();
    }
}
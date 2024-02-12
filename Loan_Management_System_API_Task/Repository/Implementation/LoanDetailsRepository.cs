using Loan_Management_System_API_Task.Data;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Repository.Interface;

namespace Loan_Management_System_API_Task.Repository.Implementation;

public class LoanDetailsRepository(DataContext context): ILoanDetailsRepository
{
    public ICollection<LoanDetails> GetLoanDetails()
    {
        throw new NotImplementedException();
    }

    public LoanDetails GetLoanDetails(int id)
    {
        throw new NotImplementedException();
    }

    public bool AddLoanDetails(LoanDetails loanDetails)
    {
        throw new NotImplementedException();
    }

    public bool UpdateLoanDetails(LoanDetails loanDetails)
    {
        throw new NotImplementedException();
    }

    public bool DeleteLoanDetails(int id)
    {
        throw new NotImplementedException();
    }

    public bool Save()
    {
        throw new NotImplementedException();
    }
}
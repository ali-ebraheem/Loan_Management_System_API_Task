using Loan_Management_System_API_Task.Data;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Repository.Interface;

namespace Loan_Management_System_API_Task.Repository.Implementation;

public class LoanRepaymentRepository(DataContext context): ILoanRepaymentRepository
{
    public ICollection<LoanRepayment> GetAllLoanRepayments()
    {
        throw new NotImplementedException();
    }

    public LoanRepayment GetLoanRepaymentById(int id)
    {
        throw new NotImplementedException();
    }

    public bool AddLoanRepayment(LoanRepayment loanRepayment)
    {
        throw new NotImplementedException();
    }

    public bool UpdateLoanRepayment(LoanRepayment loanRepayment)
    {
        throw new NotImplementedException();
    }

    public bool DeleteLoanRepayment(int id)
    {
        throw new NotImplementedException();
    }

    public bool Save()
    {
        throw new NotImplementedException();
    }
}
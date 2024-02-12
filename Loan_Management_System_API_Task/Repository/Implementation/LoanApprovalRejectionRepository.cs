using Loan_Management_System_API_Task.Data;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Repository.Interface;

namespace Loan_Management_System_API_Task.Repository.Implementation;

public class LoanApprovalRejectionRepository(DataContext context): ILoanApprovalRejectionRepository
{
    public ICollection<LoanApprovalRejection> GetAllLoanApprovalRejections()
    {
        throw new NotImplementedException();
    }

    public LoanApprovalRejection GetLoanApprovalRejectionById(int id)
    {
        throw new NotImplementedException();
    }

    public bool AddLoanApprovalRejection(LoanApprovalRejection loanApprovalRejection)
    {
        throw new NotImplementedException();
    }

    public bool UpdateLoanApprovalRejection(LoanApprovalRejection loanApprovalRejection)
    {
        throw new NotImplementedException();
    }

    public bool DeleteLoanApprovalRejection(int id)
    {
        throw new NotImplementedException();
    }

    public bool Save()
    {
        throw new NotImplementedException();
    }
}
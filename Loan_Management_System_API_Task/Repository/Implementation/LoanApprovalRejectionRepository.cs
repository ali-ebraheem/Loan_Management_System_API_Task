using Loan_Management_System_API_Task.Data;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Repository.Interface;

namespace Loan_Management_System_API_Task.Repository.Implementation;

public class LoanApprovalRejectionRepository(DataContext context) : ILoanApprovalRejectionRepository
{
    public ICollection<LoanApprovalRejection> GetAllLoanApprovalRejections()
    {
        return context.LoanApprovalRejections.ToList();
    }

    public LoanApprovalRejection GetLoanApprovalRejectionById(int id)
    {
        return context.LoanApprovalRejections.FirstOrDefault(l => l.Id == id)!;
    }

    public bool AddLoanApprovalRejection(LoanApprovalRejection loanApprovalRejection)
    {
        context.LoanApprovalRejections.Add(loanApprovalRejection);
        return Save();
    }

    public bool UpdateLoanApprovalRejection(LoanApprovalRejection loanApprovalRejection)
    {
        context.LoanApprovalRejections.Update(loanApprovalRejection);
        return Save();
    }

    public bool DeleteLoanApprovalRejection(int id)
    {
        var loanApprovalRejection = context.LoanApprovalRejections.FirstOrDefault(l => l.Id == id);

        context.LoanApprovalRejections.Remove(loanApprovalRejection);
        return Save();
    }

    public bool Save()
    {
        var save = context.SaveChanges();
        return save > 0;
    }
}
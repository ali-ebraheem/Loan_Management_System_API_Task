using Loan_Management_System_API_Task.Data;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Repository.Interface;

namespace Loan_Management_System_API_Task.Repository.Implementation;

public class LoanRepaymentRepository(DataContext context) : ILoanRepaymentRepository
{
    public ICollection<LoanRepayment> GetAllLoanRepayments()
    {
        return context.LoanRepayments.ToList();
    }

    public LoanRepayment GetLoanRepaymentById(int id)
    {
        return context.LoanRepayments.FirstOrDefault(l => l.Id == id)!;
    }

    public bool AddLoanRepayment(LoanRepayment loanRepayment)
    {
        context.LoanRepayments.Add(loanRepayment);
        return Save();
    }

    public bool UpdateLoanRepayment(LoanRepayment loanRepayment)
    {
        context.LoanRepayments.Update(loanRepayment);
        return Save();
    }

    public bool DeleteLoanRepayment(int id)
    {
        var loanRepayment = context.LoanRepayments.FirstOrDefault(l => l.Id == id)!;
        context.LoanRepayments.Remove(loanRepayment);
        return Save();
    }

    public bool Save()
    {
        var save = context.SaveChanges();
        return save > 0;
    }
}
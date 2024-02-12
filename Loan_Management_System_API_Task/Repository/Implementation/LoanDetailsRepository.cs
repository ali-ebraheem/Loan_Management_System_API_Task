using Loan_Management_System_API_Task.Data;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Repository.Interface;

namespace Loan_Management_System_API_Task.Repository.Implementation;

public class LoanDetailsRepository(DataContext context) : ILoanDetailsRepository
{
    public ICollection<LoanDetails> GetLoanDetails()
    {
        return context.LoanDetails.ToList();
    }

    public LoanDetails GetLoanDetails(int id)
    {
        return context.LoanDetails.FirstOrDefault(ld => ld.Id == id)!;
    }

    public bool AddLoanDetails(LoanDetails loanDetails)
    {
        context.LoanDetails.Add(loanDetails);
        return Save();
    }

    public bool UpdateLoanDetails(LoanDetails loanDetails)
    {
        context.LoanDetails.Update(loanDetails);
        return Save();
    }

    public bool DeleteLoanDetails(int id)
    {
        var loanDetails = context.LoanDetails.FirstOrDefault(ld => ld.Id == id)!;
        context.LoanDetails.Remove(loanDetails);
        return Save();
    }

    public bool Save()
    {
        var save = context.SaveChanges();
        return save > 0;
    }
}
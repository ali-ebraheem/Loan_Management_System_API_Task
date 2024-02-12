using Loan_Management_System_API_Task.Data;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Repository.Interface;

namespace Loan_Management_System_API_Task.Repository.Implementation;

public class LoanApplicationRepository(DataContext context) : ILoanApplicationRepository
{
    public ICollection<LoanApplication> GetLoanApplications()
    {
        return context.LoanApplications.ToList();
    }

    public LoanApplication GetLoanApplication(int id)
    {
        return context.LoanApplications.FirstOrDefault(la => la.Id == id)!;
    }

    public bool AddLoanApplication(LoanApplication loanApplication)
    {
        context.LoanApplications.Add(loanApplication);
        return Save();
    }

    public bool UpdateLoanApplication(LoanApplication loanApplication)
    {
        context.LoanApplications.Update(loanApplication);
        return Save();
    }

    public bool DeleteLoanApplication(int id)
    {
        var loanApplication = context.LoanApplications.FirstOrDefault(la => la.Id == id)!;

        context.LoanApplications.Remove(loanApplication);
        return Save();
    }


    public bool Save()
    {
        var save = context.SaveChanges();
        return save > 0;
    }
}
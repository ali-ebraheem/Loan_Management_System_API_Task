using AutoMapper;
using Loan_Management_System_API_Task.Commands;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Repository.Interface;
using MediatR;

namespace Loan_Management_System_API_Task.Handlers;

public class LoanRepaymentHandlers(
    IMapper mapper,
    ILoanRepaymentRepository loanRepaymentRepository,
    ILoanApplicationRepository
        loanApplicationRepository,
    IUserRepository userRepository) : IRequestHandler<LoanRepaymentCommand, LoanRepayment>
{
    public Task<LoanRepayment> Handle(LoanRepaymentCommand request, CancellationToken cancellationToken)
    {
        var loanApplication = loanApplicationRepository.GetLoanApplication(request.LoanRepaymentDto.LoanApplicationId);
        if (loanApplication is null)
            return null!;
        var user = userRepository.GetUserById(request.LoanRepaymentDto.UserId);
        if (user is null)
            return null!;
        var loanRepayment = mapper.Map<LoanRepayment>(request.LoanRepaymentDto);
        loanRepayment.LoanApplication = loanApplication;
        loanRepayment.User = user;
        loanRepayment.PaymentDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        loanRepaymentRepository.AddLoanRepayment(loanRepayment);
        return Task.FromResult(loanRepayment);
    }
}
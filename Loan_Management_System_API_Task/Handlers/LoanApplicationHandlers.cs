using AutoMapper;
using Loan_Management_System_API_Task.Commands;
using Loan_Management_System_API_Task.Enum;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Repository.Interface;
using MediatR;

namespace Loan_Management_System_API_Task.Handlers;

public class LoanApplicationHandlers(
    ILoanApplicationRepository applicationRepository,
    IUserRepository userRepository,
    IMapper mapper) : IRequestHandler<LoanApplicationCommand, LoanApplication>
{
    public Task<LoanApplication> Handle(LoanApplicationCommand request, CancellationToken cancellationToken)
    {
        var loanApplication = applicationRepository.GetLoanApplication(request.LoanApplicationDto.Id);
        if (loanApplication is not null)
            return null!;
        var user = userRepository.GetUserById(request.LoanApplicationDto.UserId);
        if (user is null)
            return null!;

        var loanApplicationModel = mapper.Map<LoanApplication>(request.LoanApplicationDto);
        loanApplicationModel.User = user;
        loanApplicationModel.Status = LoanStatus.Pending;
        applicationRepository.AddLoanApplication(loanApplicationModel);
        return Task.FromResult(loanApplicationModel);
    }
}
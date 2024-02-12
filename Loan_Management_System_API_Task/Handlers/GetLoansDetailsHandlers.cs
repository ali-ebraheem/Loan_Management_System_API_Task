using AutoMapper;
using Loan_Management_System_API_Task.Dto;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Queries;
using Loan_Management_System_API_Task.Repository.Interface;
using MediatR;

namespace Loan_Management_System_API_Task.Handlers;

public class GetLoansDetailsHandlers(ILoanDetailsRepository loanDetailsRepository, IMapper mapper)
    : IRequestHandler<GetLoansDetailsQueries, ICollection<LoanDetailsDto>>
{
    public Task<ICollection<LoanDetailsDto>> Handle(GetLoansDetailsQueries request, CancellationToken cancellationToken)
    {
        var loanDetails = mapper.Map<ICollection<LoanDetailsDto>>(loanDetailsRepository.GetLoanDetails());
        return Task.FromResult(loanDetails);
    }
}
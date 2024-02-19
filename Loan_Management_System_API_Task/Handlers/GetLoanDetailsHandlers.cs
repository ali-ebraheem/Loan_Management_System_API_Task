using AutoMapper;
using Loan_Management_System_API_Task.Dto;
using Loan_Management_System_API_Task.Queries;
using Loan_Management_System_API_Task.Repository.Interface;
using MediatR;

namespace Loan_Management_System_API_Task.Handlers;

public class GetLoanDetailsHandlers(ILoanDetailsRepository detailsRepository, IMapper mapper)
    : IRequestHandler<GetLoanDetailsQueries, LoanDetailsDto>
{
    public Task<LoanDetailsDto> Handle(GetLoanDetailsQueries request, CancellationToken cancellationToken)
    {
        var loanDetails = mapper.Map<LoanDetailsDto>(detailsRepository.GetLoanDetails(request.Id));
        return Task.FromResult(loanDetails);
    }
}
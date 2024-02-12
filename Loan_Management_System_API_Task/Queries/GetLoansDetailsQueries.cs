using Loan_Management_System_API_Task.Dto;
using MediatR;

namespace Loan_Management_System_API_Task.Queries;

public abstract class GetLoansDetailsQueries: IRequest<ICollection<LoanDetailsDto>>
{
    
    
}
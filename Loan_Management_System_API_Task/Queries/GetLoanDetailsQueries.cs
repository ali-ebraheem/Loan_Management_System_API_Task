using Loan_Management_System_API_Task.Dto;
using MediatR;

namespace Loan_Management_System_API_Task.Queries;

public abstract class GetLoanDetailsQueries(int id): IRequest<LoanDetailsDto>
{
    public int Id { get; set; }=id;
    
   
}
using Loan_Management_System_API_Task.Dto;
using Loan_Management_System_API_Task.Models;
using MediatR;

namespace Loan_Management_System_API_Task.Commands;

public class LoanRepaymentCommand(LoanRepaymentDto loanRepaymentDto): IRequest<LoanRepayment>
{
    public LoanRepaymentDto LoanRepaymentDto { get; set; } = loanRepaymentDto;
    
    
}
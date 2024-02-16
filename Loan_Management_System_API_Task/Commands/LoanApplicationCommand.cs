using Loan_Management_System_API_Task.Dto;
using Loan_Management_System_API_Task.Models;
using MediatR;

namespace Loan_Management_System_API_Task.Commands;

public class LoanApplicationCommand(LoanApplicationDto loanApplicationDto) : IRequest<LoanApplication>
{
    public LoanApplicationDto LoanApplicationDto { get; set; } = loanApplicationDto;
}
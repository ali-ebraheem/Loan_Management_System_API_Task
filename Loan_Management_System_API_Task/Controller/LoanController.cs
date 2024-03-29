using Loan_Management_System_API_Task.Commands;
using Loan_Management_System_API_Task.Dto;
using Loan_Management_System_API_Task.Queries;
using Loan_Management_System_API_Task.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loan_Management_System_API_Task.Controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class LoanController(IMediator mediator, IMessageProducer messageProducer) : ControllerBase
{
    [HttpGet]
    [Authorize]
    [ProducesResponseType(typeof(ICollection<LoanDetailsDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Task<IActionResult> GetDetails()
    {
        var query = new GetLoansDetailsQueries();
        var results = mediator.Send(query);
        return !ModelState.IsValid
            ? Task.FromResult<IActionResult>(BadRequest())
            : Task.FromResult<IActionResult>(Ok(results));
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(typeof(LoanDetailsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Task<IActionResult> GetDetailsById([FromQuery] int id)
    {
        var query = new GetLoanDetailsQueries(id);
        var results = mediator.Send(query);
        return !ModelState.IsValid
            ? Task.FromResult<IActionResult>(BadRequest())
            : Task.FromResult<IActionResult>(Ok(results));
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Task<IActionResult> CreateApplication([FromBody] LoanApplicationDto loanApplicationDto)
    {
        var command = new LoanApplicationCommand(loanApplicationDto);

        var results = mediator.Send(command);
        if (!ModelState.IsValid)
            return Task.FromResult<IActionResult>(BadRequest());
        messageProducer.SendMessage(loanApplicationDto);

        return Task.FromResult<IActionResult>(Created());
    }


    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Task<IActionResult> AddRepayment([FromBody] LoanRepaymentDto loanRepaymentDto)
    {
        var command = new LoanRepaymentCommand(loanRepaymentDto);
        var results = mediator.Send(command);
        if (!ModelState.IsValid)
            return Task.FromResult<IActionResult>(BadRequest());
        messageProducer.SendMessage(loanRepaymentDto);

        return Task.FromResult<IActionResult>(Ok());
    }
}
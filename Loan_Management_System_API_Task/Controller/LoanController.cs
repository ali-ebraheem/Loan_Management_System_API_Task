using Loan_Management_System_API_Task.Commands;
using Loan_Management_System_API_Task.Dto;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loan_Management_System_API_Task.Controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class LoanController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ICollection<LoanDetailsDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetDetails()
    {
        var query = new GetLoansDetailsQueries();
        var results = mediator.Send(query);
        if (!ModelState.IsValid)
            return BadRequest();
        return Ok(results);
    }

    [HttpGet]
    [ProducesResponseType(typeof(LoanDetailsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetDetailsById([FromQuery] int id)
    {
        var query = new GetLoanDetailsQueries(id);
        var results = mediator.Send(query);
        if (!ModelState.IsValid)
            return BadRequest();
        return Ok(results);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateApplication([FromBody] LoanApplicationDto loanApplicationDto)
    {
        var command = new LoanApplicationCommand(loanApplicationDto);

        var results = mediator.Send(command);
        if (!ModelState.IsValid)
            return BadRequest();

        return Created();
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddRepayment([FromBody] LoanRepaymentDto loanRepaymentDto)
    {
        var command = new LoanRepaymentCommand(loanRepaymentDto);
        var results = mediator.Send(command);
        if (!ModelState.IsValid)
            return BadRequest();

        return Ok();
    }
}
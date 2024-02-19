using Loan_Management_System_API_Task.Controller;
using Loan_Management_System_API_Task.Dto;
using Loan_Management_System_API_Task.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Loan_Management_System_API_Task.Test;

public class LoanControllerTest
{
    [Fact]
    public Task GetDetails_WithValidModelState_ReturnsOkResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var messageProducerMock = new Mock<IMessageProducer>();

        var loanController = new LoanController(mediatorMock.Object, messageProducerMock.Object);

        // Act
        var result =  loanController.GetDetails();

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.IsType<List<LoanDetailsDto>>(okResult!.Value);
        return Task.CompletedTask;
    }

    [Fact]
    public Task GetDetails_WithInvalidModelState_ReturnsBadRequestResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var messageProducerMock = new Mock<IMessageProducer>();

        var loanController = new LoanController(mediatorMock.Object, messageProducerMock.Object);
        loanController.ModelState.AddModelError("key", "error message");

        // Act
        var result =  loanController.GetDetails();

        // Assert
        Assert.IsType<BadRequestResult>(result);
        return Task.CompletedTask;
    }
    
        [Fact]
    public Task GetDetailsById_WithValidModelState_ReturnsOkResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var messageProducerMock = new Mock<IMessageProducer>();

        var loanController = new LoanController(mediatorMock.Object, messageProducerMock.Object);
        var id = 1; // Set your desired id

        // Act
        var result =  loanController.GetDetailsById(id);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
        return Task.CompletedTask;
    }

    [Fact]
    public Task GetDetailsById_WithInvalidModelState_ReturnsBadRequestResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var messageProducerMock = new Mock<IMessageProducer>();

        var loanController = new LoanController(mediatorMock.Object, messageProducerMock.Object);
        loanController.ModelState.AddModelError("key", "error message");

        // Act
        var result =  loanController.GetDetailsById(1);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
        return Task.CompletedTask;
    }

    [Fact]
    public void CreateApplication_WithValidModelState_ReturnsCreatedResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var messageProducerMock = new Mock<IMessageProducer>();

        var loanController = new LoanController(mediatorMock.Object, messageProducerMock.Object);
        var loanApplicationDto = new LoanApplicationDto(); // Set your desired LoanApplicationDto

        // Act
        var result =  loanController.CreateApplication(loanApplicationDto);

        // Assert
        Assert.IsType<CreatedResult>(result.Result);
    }

    [Fact]
    public Task CreateApplication_WithInvalidModelState_ReturnsBadRequestResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var messageProducerMock = new Mock<IMessageProducer>();

        var loanController = new LoanController(mediatorMock.Object, messageProducerMock.Object);
        loanController.ModelState.AddModelError("key", "error message");
        var loanApplicationDto = new LoanApplicationDto(); // Set your desired LoanApplicationDto

        // Act
        var result =  loanController.CreateApplication(loanApplicationDto);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
        return Task.CompletedTask;
    }

    [Fact]
    public Task AddRepayment_WithValidModelState_ReturnsOkResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var messageProducerMock = new Mock<IMessageProducer>();

        var loanController = new LoanController(mediatorMock.Object, messageProducerMock.Object);
        var loanRepaymentDto = new LoanRepaymentDto(); // Set your desired LoanRepaymentDto

        // Act
        var result =  loanController.AddRepayment(loanRepaymentDto);

        // Assert
        Assert.IsType<OkResult>(result);
        return Task.CompletedTask;
    }

    [Fact]
    public Task AddRepayment_WithInvalidModelState_ReturnsBadRequestResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var messageProducerMock = new Mock<IMessageProducer>();

        var loanController = new LoanController(mediatorMock.Object, messageProducerMock.Object);
        loanController.ModelState.AddModelError("key", "error message");
        var loanRepaymentDto = new LoanRepaymentDto(); // Set your desired LoanRepaymentDto

        // Act
        var result =  loanController.AddRepayment(loanRepaymentDto);

        // Assert
        Assert.IsType<BadRequestResult>(result);
        return Task.CompletedTask;
    }
} 
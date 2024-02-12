using AutoMapper;
using Loan_Management_System_API_Task.Dto;
using Loan_Management_System_API_Task.Models;

namespace Loan_Management_System_API_Task.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LoanApplication, LoanApplicationDto>().ReverseMap();
        CreateMap<LoanRepayment, LoanRepaymentDto>().ReverseMap();
        CreateMap<LoanDetails, LoanDetailsDto>().ReverseMap();
    }
}
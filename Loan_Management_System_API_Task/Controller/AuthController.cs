using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Loan_Management_System_API_Task.Dto;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Loan_Management_System_API_Task.Controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController(IConfiguration configuration, IUserRepository userRepository)
    : ControllerBase
{
    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromBody] UserLoginDto userLoginDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var authenticateUser = Authenticate(userLoginDto);

        if (authenticateUser is null)
            return NotFound("user is not found");


        var token = Generate(authenticateUser);
        return Ok(token);
    }

    private string Generate(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        IEnumerable<Claim> claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };
        var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
            configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(20),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private User Authenticate(UserLoginDto userLoginDto)
    {
        var user = userRepository.UserAuthentication(userLoginDto.Email, userLoginDto.Password);

        return user;
    }
}
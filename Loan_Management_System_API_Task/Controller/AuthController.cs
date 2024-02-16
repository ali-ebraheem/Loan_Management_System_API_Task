using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Login([FromBody] UserLoginDto userLoginDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var authenticateUser = Authenticate(userLoginDto);

        if (authenticateUser is null)
            return NotFound("user is not found");


        var token = Generate(authenticateUser);

        if (authenticateUser.RefreshToken!.Any(a => a.IsActive))
        {
            var userRefreshToken = authenticateUser.RefreshToken!.FirstOrDefault(a => a.IsActive);
            SetRefreshTokenInCookie(userRefreshToken!.Token, userRefreshToken.Expires);
            return Ok(token);
        }


        var refreshToken = GenerateRefreshToken();
        authenticateUser.RefreshToken!.Add(refreshToken);
        userRepository.UpdateUser(authenticateUser);
        SetRefreshTokenInCookie(refreshToken.Token, refreshToken.Expires);
        return Ok(token);
    }

    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult RefreshToken()
    {
        var token = Request.Cookies["refreshToken"];
        var user = userRepository.GetUserByRefreshToken(token!);
        if (user is null)
            return NotFound(token);
        var refreshToken = user.RefreshToken!.FirstOrDefault(a => a.Token == token);
        if (refreshToken is null)
            return NotFound("refresh token is not found");
        if (!refreshToken.IsActive)
            return BadRequest("refresh token is expired");

        refreshToken.Revoked = DateTime.UtcNow;
        var newRefreshToken = GenerateRefreshToken();
        user.RefreshToken!.Add(newRefreshToken);
        userRepository.UpdateUser(user);
        SetRefreshTokenInCookie(newRefreshToken.Token, newRefreshToken.Expires);
        var newToken = Generate(user);
        return Ok(newToken);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult RevokeToken()
    {
        var token = Request.Cookies["refreshToken"];
        var user = userRepository.GetUserByRefreshToken(token!);
        if (user is null)
            return NotFound(token);
        var refreshToken = user.RefreshToken!.FirstOrDefault(a => a.Token == token);
        if (refreshToken is null)
            return NotFound("refresh token is not found");

        if (!refreshToken.IsActive)
            return BadRequest("refresh token is expired");

        refreshToken.Revoked = DateTime.UtcNow;
        userRepository.UpdateUser(user);
        return Ok("refresh token is revoked");
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
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private User Authenticate(UserLoginDto userLoginDto)
    {
        var user = userRepository.UserAuthentication(userLoginDto.Email, userLoginDto.Password);

        return user;
    }

    private static RefreshToken GenerateRefreshToken()
    {
        var randomNumber = new byte[32];

        using var generator = new RNGCryptoServiceProvider();

        generator.GetBytes(randomNumber);

        return new RefreshToken
        {
            Token = Convert.ToBase64String(randomNumber),
            Expires = DateTime.UtcNow.AddHours(2),
            Created = DateTime.UtcNow
        };
    }

    private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = expires.ToLocalTime(),
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None
        };

        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
    }
}
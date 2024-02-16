using Microsoft.EntityFrameworkCore;

namespace Loan_Management_System_API_Task.Models;

[Owned]
public class RefreshToken
{
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Revoked { get; set; }
    public bool IsExpired => DateTime.UtcNow >= Expires;
    public bool IsActive => Revoked is null && !IsExpired;
}
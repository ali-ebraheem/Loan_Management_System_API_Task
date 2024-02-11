using Loan_Management_System_API_Task.Enum;
using Loan_Management_System_API_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace Loan_Management_System_API_Task.Data;

public class DataContext(DbContextOptions<DataContext> options):DbContext(options)
{
 

    public DbSet<LoanApplication> LoanApplications { get; set; }
    public DbSet<LoanDetails> LoanDetails { get; set; }
    public DbSet<LoanApprovalRejection> LoanApprovalRejections { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<LoanRepayment> LoanRepayments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasData(new User { Id = 1, Name = "Admin", Password = "Admin", Role = "Admin" });
        modelBuilder.Entity<User>()
            .HasData(new User { Id = 2, Name = "User", Password = "User", Role = "User" });
        modelBuilder.Entity<User>()
            .HasData(new User { Id = 3, Name = "Manager", Password = "Manager", Role = "Manager" });
        modelBuilder.Entity<LoanApplication>()
            .HasData(new LoanApplication { Id = 1, UserId = 1, AmountRequested = 200000, ApplicationDate = new DateTime(2021, 01, 01),  Status = LoanStatus.Approved, Purpose = "Personal"});
        modelBuilder.Entity<LoanApplication>()
            .HasData(new LoanApplication { Id = 2, UserId = 2, AmountRequested = 100000, ApplicationDate = new DateTime(2021, 01, 02),  Status = LoanStatus.Rejected, Purpose = "Business"});
        modelBuilder.Entity<LoanApplication>()
            .HasData(new LoanApplication { Id = 3, UserId = 3, AmountRequested = 300000, ApplicationDate = new DateTime(2021, 01, 03),  Status = LoanStatus.Pending, Purpose = "Education"});
        modelBuilder.Entity<LoanDetails>()
            .HasData(new LoanDetails { Id = 1, LoanApplicationId = 1, UserId = 1 });
        modelBuilder.Entity<LoanDetails>()
            .HasData(new LoanDetails { Id = 2, LoanApplicationId = 2, UserId = 2 });
        modelBuilder.Entity<LoanDetails>()
            .HasData(new LoanDetails { Id = 3, LoanApplicationId = 3, UserId = 3 });
        modelBuilder.Entity<LoanApprovalRejection>()
            .HasData(new LoanApprovalRejection { Id = 1, LoanApplicationId = 1, ApproverId = 1, Status =LoanStatus.Approved, ApprovalRejectionDate = new DateTime(2021, 01, 01) });
        modelBuilder.Entity<LoanApprovalRejection>()
            .HasData(new LoanApprovalRejection { Id = 2, LoanApplicationId = 2, ApproverId = 2, Status =LoanStatus.Rejected, ApprovalRejectionDate = new DateTime(2021, 01, 02) });
        modelBuilder.Entity<LoanApprovalRejection>()
            .HasData(new LoanApprovalRejection { Id = 3, LoanApplicationId = 3, ApproverId = 3, Status =LoanStatus.Pending, ApprovalRejectionDate = new DateTime(2021, 01, 03) });
        modelBuilder.Entity<LoanRepayment>()
            .HasData(new LoanRepayment { Id = 1, LoanApplicationId = 1, UserId = 1, AmountPaid = 20000, PaymentDate = new DateTime(2021, 01, 01) });
        modelBuilder.Entity<LoanRepayment>()
            .HasData(new LoanRepayment { Id = 2, LoanApplicationId = 2, UserId = 2, AmountPaid = 10000, PaymentDate = new DateTime(2021, 01, 02) });
        modelBuilder.Entity<LoanRepayment>()
            .HasData(new LoanRepayment { Id = 3, LoanApplicationId = 3, UserId = 3, AmountPaid = 30000, PaymentDate = new DateTime(2021, 01, 03) });
        }
    
        
    
}
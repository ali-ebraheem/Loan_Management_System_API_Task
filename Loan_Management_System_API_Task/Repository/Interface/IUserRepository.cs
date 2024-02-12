using Loan_Management_System_API_Task.Models;

namespace Loan_Management_System_API_Task.Repository.Interface;

public interface IUserRepository
{
    ICollection<User> GetAllUsers();
    User GetUserById(int id);
    bool AddUser(User user);
    bool UpdateUser(User user);
    bool DeleteUser(int id);
    bool Save();
    
}
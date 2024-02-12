using Loan_Management_System_API_Task.Data;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Repository.Interface;

namespace Loan_Management_System_API_Task.Repository.Implementation;

public class UserRepository(DataContext context): IUserRepository
{
    public ICollection<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public User GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public bool AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public bool UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public bool DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public bool Save()
    {
        throw new NotImplementedException();
    }
}
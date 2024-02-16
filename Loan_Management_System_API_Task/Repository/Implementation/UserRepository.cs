using Loan_Management_System_API_Task.Data;
using Loan_Management_System_API_Task.Models;
using Loan_Management_System_API_Task.Repository.Interface;

namespace Loan_Management_System_API_Task.Repository.Implementation;

public class UserRepository(DataContext context): IUserRepository
{
    public ICollection<User> GetAllUsers()
    {
        return context.Users.ToList();
    }

    public User GetUserById(int id)
    {
        return context.Users.FirstOrDefault(u => u.Id == id)!;
    }

    public User UserAuthentication(string email, string password)
    {
        return context.Users.FirstOrDefault(u => u.Email == email && u.Password == password)!;
    }

    public bool AddUser(User user)
    {
        context.Users.Add(user);
        return Save();
    }

    public bool UpdateUser(User user)
    {
        context.Users.Update(user);
        return Save();
    }

    public bool DeleteUser(int id)
    {
        var user = context.Users.FirstOrDefault(u => u.Id == id)!;
        context.Users.Remove(user);
        return Save();
    }

    public bool Save()
    {
        var save = context.SaveChanges();
        return save > 0;
    }
}
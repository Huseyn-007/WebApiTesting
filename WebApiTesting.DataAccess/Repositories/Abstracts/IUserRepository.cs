using WebApiTesting.Entities;

namespace WebApiTesting.DataAccess.Repositories.Abstracts;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task AddAsync(User user);
    Task DeleteAsync(User user);
    Task UpdateAsync(User user);
}

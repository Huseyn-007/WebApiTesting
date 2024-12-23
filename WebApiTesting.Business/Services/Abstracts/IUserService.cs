using WebApiTesting.Entities;

namespace WebApiTesting.Business.Services.Abstracts;

public interface IUserService
{
    Task AddAsync(User user);
    Task DeleteAsync(User user);
    Task UpdateAsync(User user);
    Task<User> GetByIdAsync(int id);
    Task<List<User>> GetAllAsync();
}

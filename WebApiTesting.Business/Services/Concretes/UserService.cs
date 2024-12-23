using Microsoft.EntityFrameworkCore.Storage.Json;
using WebApiTesting.Business.Services.Abstracts;
using WebApiTesting.DataAccess.Repositories.Abstracts;
using WebApiTesting.Entities;

namespace WebApiTesting.Business.Services.Concretes;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(User user)
    {
        await _repository.AddAsync(user);
    }

    public async Task DeleteAsync(User user)
    {
        await _repository.DeleteAsync(user);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);  
    }

    public async Task UpdateAsync(User user)
    {
        await _repository.UpdateAsync(user);   
    }
}

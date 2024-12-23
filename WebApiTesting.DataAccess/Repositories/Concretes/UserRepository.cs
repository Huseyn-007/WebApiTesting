using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApiTesting.DataAccess.Data;
using WebApiTesting.DataAccess.Repositories.Abstracts;
using WebApiTesting.Entities;

namespace WebApiTesting.DataAccess.Repositories.Concretes;

public class UserRepository : IUserRepository
{
    private readonly WebApiTestingDbContext _context;

    public UserRepository(WebApiTestingDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

    }

    public async Task DeleteAsync(User user)
    {
         _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(User user)
    {
         _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}

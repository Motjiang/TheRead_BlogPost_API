using TheRead_BlogPost_API.Models.Domains;

namespace TheRead_BlogPost_API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(Guid id);
    }
}

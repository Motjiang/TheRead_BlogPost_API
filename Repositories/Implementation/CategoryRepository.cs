using Microsoft.EntityFrameworkCore;
using TheRead_BlogPost_API.Data;
using TheRead_BlogPost_API.Models.Domains;
using TheRead_BlogPost_API.Repositories.Interface;

namespace TheRead_BlogPost_API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        //DI (Dependency Injection) is used to inject the DbContext into the constructor
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            //Add the category to the database
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            //Return all categories from the database
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            //Return the category with the specified id
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> UpdateCategoryAsync(Category category)
        {
            var existingCategory =  await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);

            if(existingCategory != null)
            {
                _context.Entry(existingCategory).CurrentValues.SetValues(category);
                await _context.SaveChangesAsync();
                return category;
            }
            return null;
        }
    }
}

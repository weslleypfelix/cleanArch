using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _categoryDbContext;
        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _categoryDbContext = applicationDbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _categoryDbContext.Add(category);
            await _categoryDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            return await _categoryDbContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryDbContext.Categories.ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            _categoryDbContext.Remove(category);
            await _categoryDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _categoryDbContext.Update(category);
            await _categoryDbContext.SaveChangesAsync();
            return category;
        }
    }
}

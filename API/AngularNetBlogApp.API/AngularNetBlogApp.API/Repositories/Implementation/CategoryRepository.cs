using AngularNetBlogApp.API.Data;
using AngularNetBlogApp.API.Models.Domain;
using AngularNetBlogApp.API.Repositories.Interface;

namespace AngularNetBlogApp.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        }
    }
}

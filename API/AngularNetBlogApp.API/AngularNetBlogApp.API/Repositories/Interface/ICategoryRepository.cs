using AngularNetBlogApp.API.Models.Domain;

namespace AngularNetBlogApp.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
    }
}

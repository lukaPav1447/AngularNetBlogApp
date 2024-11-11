using AngularNetBlogApp.API.Models.Domain;

namespace AngularNetBlogApp.API.Repositories.Interface
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost);
    }
}

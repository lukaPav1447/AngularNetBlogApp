using AngularNetBlogApp.API.Models.Domain;
using AngularNetBlogApp.API.Models.DTO;
using AngularNetBlogApp.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AngularNetBlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogPostsController(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestDto request)
        {
            var blogPost = new BlogPost
            {
                Author = request.Author,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                UrlHandle = request.UrlHandle,
                Title = request.Title,
                PublishedDate = request.PublishedDate,
                IsVisible = request.IsVisible,
                ShortDescription = request.ShortDescription,
            };

            blogPost = await blogPostRepository.CreateAsync(blogPost);

            var response = new BlogPostDto
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                UrlHandle = blogPost.UrlHandle,
                Title = blogPost.Title,
                PublishedDate = blogPost.PublishedDate,
                IsVisible = blogPost.IsVisible,
                ShortDescription = blogPost.ShortDescription,

            };

            return Ok(response);
        }
    }
}

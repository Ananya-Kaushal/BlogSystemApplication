﻿using BlogSystem.Models.Domain;
using BlogSystem.Models.ViewModels;
using BlogSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogPostRepository blogPost;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ICommentRepository commentRepository;

        public BlogController(IBlogPostRepository blogPost,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ICommentRepository commentRepository)
        {
            this.blogPost = blogPost;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.commentRepository = commentRepository;
        }

        public async Task<IActionResult> Index(int id)
        {
            var blog = await blogPost.GetAsync(id);
            var blogDetailsViewModel = new BlogDetailsViewModel();

            if (blog != null)
            {
                // Get comments for blog post
                var blogCommentsDomainModel = await commentRepository.GetCommentsByBlogIdAsync(blog.Id);

                var commentViewModel = new List<CommentViewModel>();

                foreach (var blogComment in blogCommentsDomainModel)
                {
                    commentViewModel.Add(new CommentViewModel
                    {
                        Description = blogComment.Description,
                        DateAdded = blogComment.CreatedAt,
                        Username = (await userManager.FindByIdAsync(blogComment.UserId.ToString())).UserName
                    });
                }

                blogDetailsViewModel = new BlogDetailsViewModel
                {
                    PostId = blog.Id,
                    Content = blog.Content,
                    Title = blog.Title,
                    Author = blog.BloggerName,
                    FeaturedImageUrl = blog.FeaturedImageUrl,
                    CreatedAt = blog.CreatedAt,
                    UpdateAt = blog.UpdatedAt,
                    Comments = commentViewModel
                };

                return View(blogDetailsViewModel);
            }

            return View("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Index(BlogDetailsViewModel blogDetailsViewModel)
        {
            if (signInManager.IsSignedIn(User))
            {
                var domainModel = new Comment
                {
                    Description = blogDetailsViewModel.CommentDescription,
                    PostId = blogDetailsViewModel.PostId,
                    UserId = Guid.Parse(userManager.GetUserId(User)),
                    CreatedAt = DateTime.Now
                };

                await commentRepository.AddAsync(domainModel);
                return RedirectToAction("Index", "Blog",
                    new { PostId = blogDetailsViewModel.PostId });
            }

            return View();
        }

    }
}

using BloggieWeb.Data;
using BloggieWeb.Models.Domain;
using BloggieWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BloggieWeb.Pages.Admin.Blogs
    
{
    public class AddModel : PageModel
    {
        private readonly BloogieDbContext bloggieDbContext;

        [BindProperty]
        public AddBlogPost  AddBlogPostRequest { get; set; }
        public AddModel(BloogieDbContext bloggieDbContext) {
            this.bloggieDbContext = bloggieDbContext;
        }
        public void OnGet()
        {
        }
        public void OnPost() {
            //C1
            //var heading = Request.Form["heading"];
            //var pageTitle = Request.Form["pageTitlle"];
            //var content = Request.Form["content"];
            //var shortDesciption = Request.Form["shortDesciption"];

            //C2:connect with data
            var blogPost = new BlogPost() { 
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,   
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible,
            };

            bloggieDbContext.BlogPosts.Add(blogPost);
            bloggieDbContext.SaveChanges();
        }

    }
}

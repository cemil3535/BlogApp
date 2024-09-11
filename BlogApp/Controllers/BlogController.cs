using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        private static int _nextId = 1;
        private static List<BlogPost> _posts = new List<BlogPost>();


        public IActionResult Index()
        {
            ViewBag.TotalPosts = _posts.Count;
            ViewData["PageTitle"] = "Blog Gonderileri";

            return View(_posts);
        }

        public IActionResult Create()
        {
            ViewBag.CurrentTime = DateTime.Now;
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.Id = _nextId++;
                _posts.Add(blogPost);
                TempData["SuccessMessage"] = "Blog gonderisi basari ile olusturuldu.";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CurrentTime = DateTime.Now;
            return View(blogPost);
        }

        public IActionResult Details(int id)
        {
            var post = _posts.FirstOrDefault(x => x.Id == id);
            if (post is null)
            {
                return NotFound();
            }

            ViewData["CreatedAgo"] = $"{(DateTime.Now - post.CreatedAt).TotalMinutes} dakika once";

            return View(post);
        }
    }
}

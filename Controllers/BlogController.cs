using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using System.Linq;

namespace TimewisePortalShadow.Controllers
{
    public class BlogController : Controller
    {

        static List<BlogEntry> Posts = new List<BlogEntry>();

        public IActionResult index()
        {
            return View("Index", Posts);
        }
        public IActionResult CreatorPage(Guid id)
        {
            if(id != Guid.Empty)
            {
                BlogEntry existingEntry = Posts.FirstOrDefault(x => x.Id == id);

                return View(existingEntry);
            }

            return View();
        }

        [HttpPost]
        public IActionResult CreatorPage(BlogEntry entry)
        {
            if (entry.Id == Guid.Empty)
            {
                //New Blog Article
                BlogEntry newEntry = new BlogEntry();
                newEntry.Content = entry.Content;
                newEntry.Id = Guid.NewGuid();
                Posts.Add(newEntry);
            
            
            } else
            {
                //Existing Blog Article
                BlogEntry existingEntry = Posts.FirstOrDefault(x => x.Id == entry.Id);
                existingEntry.Content = entry.Content;
                ;           }
            
            
            return RedirectToAction("Index");
        }
    }
}

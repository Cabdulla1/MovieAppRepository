using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieWebApp.Pages
{
    public class MoviesPageModel : PageModel
    {
        public void OnGet(string name)
        {
            ViewData["name"] = name;
        }
    }
}

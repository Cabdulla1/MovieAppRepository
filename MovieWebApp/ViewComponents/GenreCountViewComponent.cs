using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieWebApp.Data;
using MovieWebApp.Models;

namespace MovieWebApp.ViewComponents
{
    public class GenreCountViewComponent:ViewComponent
    {
        private readonly MovieWebAppContext _appContext;
        public GenreCountViewComponent(MovieWebAppContext movieWebAppContext)
        {
            _appContext = movieWebAppContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(string genre)
        {
            var result = await _appContext.Movie.Where(m => m.Genre == genre)
                .GroupBy(x => x.Genre)
                .Select(x => new GenreCountViewModel { Genre = x.Key, Count = x.Count() })
                .FirstOrDefaultAsync() ?? new GenreCountViewModel 
                {
                    Genre = genre,
                    Count = 0
                };

            return View(result);
            
        }


    }

}

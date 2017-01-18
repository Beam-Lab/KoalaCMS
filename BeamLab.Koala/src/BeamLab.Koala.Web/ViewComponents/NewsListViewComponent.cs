using BeamLab.Koala.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeamLab.Koala.Web.ViewComponents
{
    public class NewsListViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(int newsCount, string category)
        {
            var items = await GetItemsAsync(newsCount, category);
            return View(items);
        }
        private Task<List<Article>> GetItemsAsync(int newsCount, string category)
        {
            return null;
        }
    }
}

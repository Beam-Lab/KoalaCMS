using BeamLab.Koala.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            var articles = new List<Article>();

            for (int i = 0; i < newsCount; i++)
            {
                articles.Add(new Article() { ID = i, Title = string.Format("Title {0} for category: {1}", i.ToString(), category), SubTitle = string.Format("Title {0} for category: {1}", i.ToString(), category), Image = "https://i.guim.co.uk/img/static/sys-images/Guardian/Pix/pictures/2015/5/22/1432299215355/baff131f-a335-44eb-ad66-03c52c5c2213-620x372.jpeg?w=700&q=85&auto=format&sharp=10&s=31a22f00a85840740c2a8af5604abfb0" });
            }

            return Task.Run(() => articles);
        }
    }
}

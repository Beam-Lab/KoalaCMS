using BeamLab.Koala.Web.Models;
using BeamLab.Koala.Web.Repository;
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
        IRepository _repository;

        public NewsListViewComponent(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int newsCount, string category)
        {
            var items = await GetItemsAsync(newsCount, category);
            return View(items);
        }

        private Task<List<Article>> GetItemsAsync(int newsCount, string category)
        {
            var articles = new List<Article>();

            switch (category)
            {
                case "featured":
                    articles = _repository.GetFeaturedArticles();
                    break;
                case "top":
                    articles = _repository.GetTopArticles();
                    break;
                case "latest":
                    articles = _repository.GetLatestArticles();
                    break;
            }

            return Task.Run(() => articles);
        }
    }
}

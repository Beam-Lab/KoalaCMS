using BeamLab.Koala.Web.Models;
using BeamLab.Koala.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeamLab.Koala.Web.ViewComponents
{
    public class NavBarViewComponent : ViewComponent
    {
        IRepository _repository;

        public NavBarViewComponent(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }

        private Task<List<Category>> GetItemsAsync()
        {
            var categories = new List<Category>();

            categories = _repository.GetNewsCategories();

            return Task.Run(() => categories);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BeamLab.Koala.Web.Models;
using BeamLab.Koala.Web.Data;
using BeamLab.Koala.Web.Repository;

namespace BeamLab.Koala.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        IRepository _repository;

        public AdminController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var articles = _repository.GetAllArticles();

            return View(articles);
        }

        public IActionResult EditNews(int? id)
        {
            var article = new Article();

            if (id.HasValue)
            {
                article = _repository.GetArticle(id.Value);
            }

            return View(article);
        }

        [HttpPost]
        public IActionResult EditNews(Article model)
        {
            _repository.SaveArticle(model);

            return RedirectToAction("Index");
        }
    }
}
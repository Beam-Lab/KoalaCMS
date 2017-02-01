using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BeamLab.Koala.Web.Models;
using BeamLab.Koala.Web.Data;

namespace BeamLab.Koala.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        ApplicationDbContext _dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var articles = _dbContext.Articles.ToList();

            return View(articles);
        }

        public IActionResult EditNews()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditNews(Article model)
        {
            var article = new Article();

            if (model.ID > 0)
            {

            }

                article =  _dbContext.Articles.Where(c => c.ID == model.ID).FirstOrDefault();

            

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
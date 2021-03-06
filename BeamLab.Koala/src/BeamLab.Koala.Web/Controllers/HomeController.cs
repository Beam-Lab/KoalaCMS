﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeamLab.Koala.Web.Repository;
using System.Text;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BeamLab.Koala.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        private ILogger _logger;

        public HomeController(IRepository repository, ILogger<HomeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [Route("", Name = "Home")]
        public IActionResult Index()
        {
            _logger.LogInformation("Call Repository: GetAllArticles");

            var articles = _repository.GetHomePageArticles();

            return View(articles);
        }

        [Route("about", Name = "About")]
        public IActionResult About()
        {

            return View();
        }

        [Route("contacts", Name = "Contacts")]
        public IActionResult Contact()
        {

            return View();
        }

        [Route("terms", Name = "Terms")]
        public IActionResult Terms()
        {

            return View();
        }

        [Route("privacy", Name = "Privacy")]
        public IActionResult Privacy()
        {

            return View();
        }

        [Route("search", Name = "Search")]
        public IActionResult Search(string query)
        {
            var absoluteUrl = Url.Action("", null, null, Request.Scheme);

            // For simplicity we are just assuming your site is indexed on Google and redirecting to it.
            return this.Redirect(string.Format(
                "https://www.google.com/?q=site:{0} {1}",
                absoluteUrl,
                query));
        }

        //[NoTrailingSlash]
        //[ResponseCache(CacheProfileName = "OpenSearchXml")]
        //[Route("opensearch.xml", Name = "OpenSearch")]
        //public IActionResult OpenSearchXml()
        //{
        //    string content = this.openSearchService.GetOpenSearchXml();
        //    return this.Content(content, ContentType.Xml, Encoding.UTF8);
        //}

        public IActionResult Article(string title)
        {
            var article = _repository.GetArticleByTitle(title);

            _repository.AddVisitToArticle(article.ID);

            ViewData["CurrentUrl"] = Request.Scheme + "://" + Request.Host + Request.Path;
            ViewData["Title"] = article.Title;
            ViewData["Description"] = article.SubTitle;
            ViewData["CurrentImage"] = article.Image;

            return View(article);
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
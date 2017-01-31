using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeamLab.Koala.Web.Repository;

namespace BeamLab.Koala.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        [Route("", Name = "Home")]
        public IActionResult Index()
        {
            return View();
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

        public IActionResult NewsDetail(string id)
        {


            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
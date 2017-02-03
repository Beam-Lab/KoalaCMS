using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeamLab.Koala.Web.Repository;
using BeamLab.Koala.Web.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BeamLab.Koala.Web.Controllers
{
    [Route("api/[controller]")]
    public class KoalaAPIController : Controller
    {
        private IRepository _repository;

        public KoalaAPIController(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Returns items.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        [Route("AllArticles")]
        [ApiExplorerSettings(GroupName = "v1")]
        public IEnumerable<Article> AllArticles()
        {
            var articles = _repository.GetAllArticles();

            return articles;
        }

        /// <summary>
        /// Returns an article.
        /// </summary>
        /// <param name="id">the article id</param>
        [HttpGet("ArticleDetail/{id}")]
        [ApiExplorerSettings(GroupName = "v1")]
        public IActionResult Article(int id)
        {
            return Ok(_repository.GetArticle(id));
        }

        /// <summary>
        /// How many articles?.
        /// </summary>
        /// <param name="count">the article count</param>
        [HttpGet]
        [Route("LatestArticles")]
        [ApiExplorerSettings(GroupName = "v1")]
        public IActionResult LatestArticle()
        {
            //if (count == 0)
            //{
            //    return BadRequest();
            //}

            var articles = _repository.GetLatestArticles();

            return Ok(articles);
        }
    }
}

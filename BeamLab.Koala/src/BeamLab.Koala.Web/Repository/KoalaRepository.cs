using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeamLab.Koala.Web.Models;
using BeamLab.Koala.Web.Data;

namespace BeamLab.Koala.Web.Repository
{
    public class KoalaRepository : IRepository
    {
        ApplicationDbContext _dbContext;

        public KoalaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetNewsCategories()
        {
            var result = new List<Category>();
            var categories = _dbContext.Articles.Select(a => a.Category).Distinct().ToList();

            foreach(string item in categories)
            {
                result.Add(new Category() { Name = item });
            }

            return result;
        }

        public List<Article> GetTopArticles()
        {
            return _dbContext.Articles.OrderByDescending(c => c.Visits).ToList();
        }

        public List<Article> GetLatestArticles()
        {
            return _dbContext.Articles.OrderByDescending(c => c.PublishDate).ToList();
        }

        public List<Article> GetFeaturedArticles()
        {
            return _dbContext.Articles.Where(c => c.Featured).ToList();
        }

        public List<Article> GetHomePageArticles()
        {
            return _dbContext.Articles.Where(c => c.HomePage).ToList();
        }

        public List<Article> GetAllArticles()
        {
            return _dbContext.Articles.ToList();
        }

        public bool SaveArticle(Article article)
        {
            article.CuratedTitle = article.Title.Replace(" ", "-");

            if (article.ID == 0)
            {
                _dbContext.Articles.Add(article);
            }
            else
            {
                _dbContext.Update(article);
            }

            _dbContext.SaveChanges();

            return true;
        }

        public Article GetArticle(int id)
        {
            return _dbContext.Articles.Where(c => c.ID == id).FirstOrDefault();
        }

        public Article GetArticleByTitle(string title)
        {
            return _dbContext.Articles.Where(c => c.CuratedTitle == title).FirstOrDefault();
        }

        public void AddVisitToArticle(int id)
        {
            var article = GetArticle(id);
            article.Visits++;

            _dbContext.Update(article);
            _dbContext.SaveChanges();
        }
    }
}

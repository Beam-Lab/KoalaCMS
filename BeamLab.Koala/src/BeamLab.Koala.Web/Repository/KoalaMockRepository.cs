using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeamLab.Koala.Web.Models;

namespace BeamLab.Koala.Web.Repository
{
    public class KoalaMockRepository : IRepository
    {
        public void AddVisitToArticle(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetAllArticles()
        {
            throw new NotImplementedException();
        }

        public Article GetArticle(int id)
        {
            throw new NotImplementedException();
        }

        public Article GetArticleByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetFeaturedArticles()
        {
            throw new NotImplementedException();
        }

        public List<Article> GetHomePageArticles()
        {
            throw new NotImplementedException();
        }

        public List<Article> GetLatestArticles()
        {
            throw new NotImplementedException();
        }

        public List<Article> GetTopArticles()
        {
            throw new NotImplementedException();
        }

        public bool SaveArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public List<string> GetNewsCategories()
        {
            throw new NotImplementedException();
        }

        List<Category> IRepository.GetNewsCategories()
        {
            throw new NotImplementedException();
        }
    }
}

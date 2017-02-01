using BeamLab.Koala.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeamLab.Koala.Web.Repository
{
    public interface IRepository
    {
        List<Category> GetNewsCategories();

        List<Article> GetTopArticles();

        List<Article> GetLatestArticles();

        List<Article> GetFeaturedArticles();

        List<Article> GetHomePageArticles();

        bool SaveArticle(Article article);

        List<Article> GetAllArticles();

        Article GetArticle(int id);

        Article GetArticleByTitle(string title);

        void AddVisitToArticle(int id);
    }
}

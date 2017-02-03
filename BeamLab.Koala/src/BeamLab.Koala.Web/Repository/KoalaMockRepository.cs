using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeamLab.Koala.Web.Models;
using System.Text;
using Microsoft.Extensions.Logging;

namespace BeamLab.Koala.Web.Repository
{
    public class KoalaMockRepository : IRepository
    {
        private ILogger _logger;

        public KoalaMockRepository(ILogger<KoalaMockRepository> logger)
        {
            _logger = logger;
        }

        public void AddVisitToArticle(int id)
        {
            return;
        }

        public List<Article> GetAllArticles()
        {
            _logger.LogInformation("Call Repository: GetAllArticles");

            return CreateRandomArticles(50);
        }

        public Article GetArticle(int id)
        {
            _logger.LogInformation("Call Repository: GetArticle - Param Value: {id}");

            var article = CreateRandomArticles(1).FirstOrDefault();
            article.ID = id;

            return article;
        }

        public Article GetArticleByTitle(string title)
        {
            var article = CreateRandomArticles(1).FirstOrDefault();
            article.CuratedTitle = title;

            return article;
        }

        public List<Article> GetFeaturedArticles()
        {
            return CreateRandomArticles(10);
        }

        public List<Article> GetHomePageArticles()
        {
            _logger.LogInformation("Call Repository: GetHomePageArticles");

            return CreateRandomArticles(20);
        }

        public List<Article> GetLatestArticles()
        {
            return CreateRandomArticles(10);
        }

        public List<Article> GetTopArticles()
        {
            return CreateRandomArticles(10);
        }

        public bool SaveArticle(Article article)
        {
            return true;
        }

        public List<Category> GetNewsCategories()
        {
            var categories = new List<Category>();

            for (int i = 0; i < 5; i++)
            {
                categories.Add(new Category() { Name = $"Category {i}" });
            }

            return categories;
        }

        private List<Article> CreateRandomArticles(int count)
        {
            var random = new Random();
            var articles = new List<Article>();

            var categories = new String[] { "city", "business", "sports", "transport", "animals", "technics", "fashion" };

            for (int i = 0; i < count; i++)
            {
                articles.Add(new Article()
                {
                    ID = i,
                    Title = $"News Title {i}",
                    HomePage = true,
                    Category = "Category 1",
                    CuratedTitle = $"News-Title-{i}",
                    Image = $"http://lorempixel.com/400/{random.Next(200, 350)}/{categories[random.Next(0, categories.Length)]}/",
                    PublishDate = RandomDate(),
                    SubTitle = $"News Subtitle {i}",
                    Body = LoremIpsum(10, 20, 20, 25, 3)
                });
            }

            return articles;
        }

        private string LoremIpsum(int minWords, int maxWords, int minSentences, int maxSentences, int numParagraphs)
        {

            var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
                                "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                                "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences)
                + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            StringBuilder result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                result.Append("<p>");
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                    }
                    result.Append(". ");
                }
                result.Append("</p>");
            }

            return result.ToString();
        }

        DateTime RandomDate()
        {
            var rand = new Random();
            var start = new DateTime(2015, 1, 1, DateTime.Now.AddHours(rand.Next(1,10)).Hour, DateTime.Now.AddHours(rand.Next(1, 10)).Minute, DateTime.Now.AddHours(rand.Next(1, 10)).Second);
            int range = (DateTime.Now - start).Days;
            return start.AddDays(rand.Next(range));
        }
    }
}

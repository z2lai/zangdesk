using ZangDesk.Core;

namespace ZangDesk.API.Services
{
    public interface IArticleRepository
    {
        Article GetArticleById(int Id);
        IEnumerable<Article> GetArticles();
    }
}

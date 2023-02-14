using ZangDesk.Core.Dtos;

namespace ZangDesk.API.Services
{
    public interface IArticleRepository
    {
        ArticleDto GetArticleById(int Id);
        IEnumerable<ArticleDto> GetArticles();

    }
}

using PersonalBlog.Entities.Dtos.ArticleDtos;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Service.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticlesDto>> Get(int articleId);
        Task<IDataResult<ArticlesUpdateDto>> GetUpdateDto(int articleId);
        Task<IDataResult<ArticlesListDto>> GetAll();
        Task<IDataResult<ArticlesListDto>> GetAllByNonDelete();
        Task<IDataResult<ArticlesListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<ArticlesListDto>> GetAllByNonDeleteAndActiveWithCategoryId(int categoryId);
        Task<IDataResult<ArticlesListDto>> GetAllByNonDeleteAndActiveOrderByDescendingId();
        Task<IDataResult<ArticlesListDto>> Get3MostReadByNonDeleteAndActive();
        Task<IDataResult<ArticlesDto>> Add(ArticlesAddDto articleAddDto, string createdByName);
        Task<IDataResult<ArticlesDto>> Update(ArticlesUpdateDto articleUpdateDto, string modifiedByName);
        Task<IResult> AddViews(int articleId);
        Task<IResult> Delete(int articleId, string modifiedByName);
        Task<IResult> HardDelete(int articleId);
    }
}

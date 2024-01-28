using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.ArticleDtos;
using PersonalBlog.Service.Abstract;
using PersonalBlog.Shared.Utilities.Abstract;
using PersonalBlog.Shared.Utilities.ComplexTypes;
using PersonalBlog.Shared.Utilities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Service.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<ArticlesDto>> Add(ArticlesAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Articles>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            var addedArticle = await _unitOfWork.Article.AddAsync(article);
            await _unitOfWork.SaveAsync();
            return new DataResult<ArticlesDto>(ResultStatus.Success, $"{articleAddDto.Title} başlıklı makale başarılı bir şekilde kayıt edilmiştir!", new ArticlesDto
            {
                Articles = addedArticle,
                ResultStatus = ResultStatus.Success,
                Message = $"{articleAddDto.Title} başlıklı makale başarılı bir şekilde kayıt edilmiştir!"
            });
        }

        public async Task<IResult> AddViews(int articleId)
        {
            var article = await _unitOfWork.Article.GetAsync(x => x.Id == articleId);
            if (article != null)
            {
                article.ViewsCount = article.ViewsCount + 1;
                await _unitOfWork.Article.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var article = await _unitOfWork.Article.GetAsync(x => x.Id == articleId);
            if (article != null)
            {
                article.IsDelete = true;
                article.ModifiedByName = modifiedByName;
                article.ModifiedTime = DateTime.Now;
                await _unitOfWork.Article.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<ArticlesDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Article.GetAsync(x => x.Id == articleId, x => x.Categories,x => x.Comments);
            if (article != null)
            {
                return new DataResult<ArticlesDto>(ResultStatus.Success, new ArticlesDto
                {
                    Articles = article,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticlesDto>(ResultStatus.Error, "Hata, kayıt bulunamadı!", new ArticlesDto
            {
                Articles = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıt bulunamadı!"
            });
        }

        public async Task<IDataResult<ArticlesListDto>> Get3MostReadByNonDeleteAndActive()
        {
            var articles = await _unitOfWork.Article.GetMostReadAsync(x => x.IsDelete == false && x.IsActive == true, x => x.Categories, x => x.Comments);
            if (articles.Counts > -1)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticlesListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new ArticlesListDto
            {
                Articles = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<ArticlesListDto>> GetAll()
        {
            var articles = await _unitOfWork.Article.GetAllAsync(null, x => x.Categories, x => x.Comments);
            if (articles.Count > -1)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticlesListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new ArticlesListDto
            {
                Articles = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<ArticlesListDto>> GetAllByNonDelete()
        {
            var articles = await _unitOfWork.Article.GetAllAsync(x => x.IsDelete == false, x => x.Categories, x => x.Comments);
            if (articles.Count > -1)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticlesListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new ArticlesListDto
            {
                Articles = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<ArticlesListDto>> GetAllByNonDeleteAndActive()
        {
            var articles = await _unitOfWork.Article.GetAllAsync(x => x.IsDelete == false && x.IsActive == true, x => x.Category, x => x.Comments);
            if (articles.Counts > -1)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticlesListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new ArticlesListDto
            {
                Articles = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<ArticlesListDto>> GetAllByNonDeleteAndActiveOrderByDescendingId()
        {
            var articles = await _unitOfWork.Article.GetAllOrderByDescIdAsync(x => x.IsDelete == false && x.IsActive == true,x => x.Categories,x => x.Comments);
            if (articles.Counts > -1)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticlesListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new ArticlesListDto
            {
                Articles = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<ArticlesListDto>> GetAllByNonDeleteAndActiveWithCategoryId(int categoryId)
        {
            var articles = await _unitOfWork.Article.GetAllAsync(x => x.IsDelete == false && x.IsActive == true && x.CategoryId==categoryId, x => x.Categories, x => x.Comments);
            if (articles.Count > -1)
            {
                return new DataResult<ArticlesListDto>(ResultStatus.Success, new ArticlesListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticlesListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new ArticlesListDto
            {
                Articles = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<ArticlesUpdateDto>> GetUpdateDto(int articleId)
        {
            var article = await _unitOfWork.Article.GetAsync(x => x.Id == articleId,x => x.Categories, x => x.Comments);
            if (article != null)
            {
                var articleUpdateDto = _mapper.Map<ArticlesUpdateDto>(article);
                return new DataResult<ArticlesUpdateDto>(ResultStatus.Success,articleUpdateDto);
            }
            return new DataResult<ArticlesUpdateDto>(ResultStatus.Success,"Hata, kayıt bulunamadı!",null);
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var article = await _unitOfWork.Article.GetAsync(x => x.Id == articleId);
            if (article != null)
            {
                await _unitOfWork.Article.DeleteAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale başarılı bir şekilde veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<ArticlesDto>> Update(ArticlesUpdateDto articleUpdateDto, string modifiedByName)
        {
            var article = _mapper.Map<Articles>(articleUpdateDto);
            article.ModifiedByName = modifiedByName;
            var updatedArticle = await _unitOfWork.Article.UpdateAsync(article);
            await _unitOfWork.SaveAsync();
            return new DataResult<ArticlesDto>(ResultStatus.Success, new ArticlesDto
            {
                Articles = updatedArticle,
                ResultStatus = ResultStatus.Success
            });
        }
    }
}
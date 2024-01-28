using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.CommentDtos;
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
    public class CommentManager : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CommentManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<CommentDto>> Add(CommentAddDto commentAddDto, string createdByName)
        {
            var comment = _mapper.Map<Comments>(commentAddDto);
            comment.CreatedByName = createdByName;
            comment.ModifiedByName = createdByName;
            comment.ModifiedTime = DateTime.Now;
            var addedComment = await _unitOfWork.Comment.AddAsync(comment);
            await _unitOfWork.SaveAsync();
            return new DataResult<CommentDto>(ResultStatus.Success, "İşlem başarılı..", new CommentDto
            {
                Comments = addedComment,
                Message = "İşlem başarılı..",
                ResultStatus = ResultStatus.Success
            });
        }

        public async Task<IResult> Delete(int commentId, string modifiedByName)
        {
            var comment = await _unitOfWork.Comment.GetAsync(x => x.Id == commentId);
            if (comment != null)
            {
                comment.IsDelete = true;
                comment.ModifiedTime = DateTime.Now;
                comment.ModifiedByName = modifiedByName;
                await _unitOfWork.Comment.UpdateAsync(comment);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "İşlem başarılı..");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IResult> DoActive(int commentId, string modifiedByName)
        {
            var comment = await _unitOfWork.Comment.GetAsync(x => x.Id == commentId);
            if (comment != null)
            {
                comment.IsActive = true;
                await _unitOfWork.Comment.UpdateAsync(comment);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{comment.FirstName} isimli kişinin yorumu başarılı bir şekilde onaylanmıştır.");
            }
            return new Result(ResultStatus.Error,"Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<CommentDto>> Get(int commentId)
        {
            var comment = await _unitOfWork.Comment.GetAsync(x => x.Id == commentId,x => x.Articles);
            if (comment != null)
            {
                return new DataResult<CommentDto>(ResultStatus.Success, new CommentDto
                {
                    Comments = comment,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CommentDto>(ResultStatus.Error, "Hata, kayıt bulunamadı!", new CommentDto
            {
                Comments = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıt bulunamadı!"
            });
        }

        public async Task<IDataResult<CommentListDto>> GetAll()
        {
            var comments = await _unitOfWork.Comment.GetAllAsync(null,x => x.Articles);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new CommentListDto
            {
                ResultStatus = ResultStatus.Error,
                Comments = null,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<CommentListDto>> GetAllByNonDelete()
        {
            var comments = await _unitOfWork.Comment.GetAllAsync(x => x.IsDelete == false, x => x.Articles);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new CommentListDto
            {
                ResultStatus = ResultStatus.Error,
                Comments = null,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<CommentListDto>> GetAllByNonDeleteAndActive()
        {
            var comments = await _unitOfWork.Comment.GetAllAsync(x => x.IsDelete == false && x.IsActive == true, x => x.Articles);
            if (comments.Count > -1)
            {
                return new DataResult<CommentListDto>(ResultStatus.Success, new CommentListDto
                {
                    Comments = comments,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CommentListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new CommentListDto
            {
                ResultStatus = ResultStatus.Error,
                Comments = null,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<CommentUpdateDto>> GetUpdateDto(int commentId)
        {
            var comment = await _unitOfWork.Comment.GetAsync(x => x.Id == commentId, x => x.Articles);
            if (comment != null)
            {
                var commentUpdateDto = _mapper.Map<CommentUpdateDto>(comment);
                return new DataResult<CommentUpdateDto>(ResultStatus.Success,commentUpdateDto);
            }
            return new DataResult<CommentUpdateDto>(ResultStatus.Error,"Hata, kayıt bulunamadı!",null);
        }

        public async Task<IResult> HardDelete(int commentId)
        {
            var comment = await _unitOfWork.Comment.GetAsync(x => x.Id == commentId);
            if (comment != null)
            {
                await _unitOfWork.Comment.DeleteAsync(comment);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "İşlem başarılı..");
            }
            return new Result(ResultStatus.Error, "Hata kayıt bulunamadı!");
        }

        public async Task<IDataResult<CommentDto>> Update(CommentUpdateDto commentUpdateDto, string modifiedByName)
        {
            var comment = _mapper.Map<Comments>(commentUpdateDto);
            comment.ModifiedByName = modifiedByName;
            var updatedComment = await _unitOfWork.Comment.UpdateAsync(comment);
            await _unitOfWork.SaveAsync();
            return new DataResult<CommentDto>(ResultStatus.Success, new CommentDto
            {
                Comments = updatedComment,
                ResultStatus = ResultStatus.Success,

            });
        }
    }
}
using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.InterestedsDtos;
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
    public class InterestedManager : IInterestedsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InterestedManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<InterestedsDto>> Add(InterestedsAddDto interestedAddDto, string createdByName)
        {
            var interested = _mapper.Map<Interesteds>(interestedAddDto);
            interested.CreatedByName = createdByName;
            interested.ModifiedByName = createdByName;
            interested.ModifiedTime = DateTime.Now;
            var addedInterested = await _unitOfWork.Interested.AddAsync(interested);
            await _unitOfWork.SaveAsync();
            return new DataResult<InterestedsDto>(ResultStatus.Success, $"{interested.Text} hobisi başarılı bir şekilde kayıt edilmiştir.", new InterestedsDto
            {
                Interesteds = addedInterested,
                ResultStatus = ResultStatus.Success,
                Message = $"{interested.Text} hobisi başarılı bir şekilde kayıt edilmiştir."
            });
        }

        public async Task<IResult> Delete(int interestedId, string modifiedByName)
        {
            var interested = await _unitOfWork.Interested.GetAsync(x => x.Id == interestedId);
            if (interested != null)
            {
                interested.IsDelete = true;
                interested.ModifiedTime = DateTime.Now;
                interested.ModifiedByName = modifiedByName;
                await _unitOfWork.Interested.UpdateAsync(interested);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{interested.Text} hobisi başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<InterestedsDto>> Get(int interestedId)
        {
            var interested = await _unitOfWork.Interested.GetAsync(x => x.Id == interestedId);
            if (interested != null)
            {
                return new DataResult<InterestedsDto>(ResultStatus.Success, new InterestedsDto
                {
                    ResultStatus = ResultStatus.Success,
                    Interesteds = interested,
                });
            }
            return new DataResult<InterestedsDto>(ResultStatus.Error, "Hata, kayıt bulunamadı!", new InterestedsDto
            {
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıt bulunamadı!",
                Interesteds = null
            });
        }

        public async Task<IDataResult<InterestedsListDto>> GetAll()
        {
            var interesteds = await _unitOfWork.Interested.GetAllAsync();
            if (interesteds.Count > -1)
            {
                return new DataResult<InterestedsListDto>(ResultStatus.Success, new InterestedsListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Interesteds = interesteds
                });
            }
            return new DataResult<InterestedsListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new InterestedsListDto
            {
                ResultStatus = ResultStatus.Error,
                Interesteds = null,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<InterestedsListDto>> GetAllByNonDelete()
        {
            var interesteds = await _unitOfWork.Interested.GetAllAsync(x => x.IsDelete == false);
            if (interesteds.Count > -1)
            {
                return new DataResult<InterestedsListDto>(ResultStatus.Success, new InterestedsListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Interesteds = interesteds
                });
            }
            return new DataResult<InterestedsListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new InterestedsListDto
            {
                ResultStatus = ResultStatus.Error,
                Interesteds = null,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<InterestedsListDto>> GetAllByNonDeleteAndActive()
        {
            var interesteds = await _unitOfWork.Interested.GetAllAsync(x => x.IsDelete == false && x.IsActive == true);
            if (interesteds.Count > -1)
            {
                return new DataResult<InterestedsListDto>(ResultStatus.Success, new InterestedsListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Interesteds = interesteds
                });
            }
            return new DataResult<InterestedsListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new InterestedsListDto
            {
                ResultStatus = ResultStatus.Error,
                Interesteds = null,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<InterestedsUpdateDto>> GetUpdateDto(int interestedDto)
        {
            var interested = await _unitOfWork.Interested.GetAsync(x => x.Id == interestedDto);
            if (interested != null)
            {
                var interestedUpdateDto = _mapper.Map<InterestedsUpdateDto>(interested);
                return new DataResult<InterestedsUpdateDto>(ResultStatus.Success,interestedUpdateDto);
            }
            return new DataResult<InterestedsUpdateDto>(ResultStatus.Error,"Hata, kayıt bulunamadı!",null);
        }

        public async Task<IResult> HardDelete(int interestedId)
        {
            var interested = await _unitOfWork.Interested.GetAsync(x => x.Id == interestedId);
            if (interested != null)
            {
                await _unitOfWork.Interested.DeleteAsync(interested);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{interested.Text} hobisi başarılı bir şekilde veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<InterestedsDto>> Update(InterestedsUpdateDto ınterestedUpdateDto, string modifiedByName)
        {
            var interested = _mapper.Map<Interesteds>(ınterestedUpdateDto);
            interested.ModifiedByName = modifiedByName;
            var updatedInterested = await _unitOfWork.Interested.UpdateAsync(interested);
            await _unitOfWork.SaveAsync();
            return new DataResult<InterestedsDto>(ResultStatus.Success, $"{updatedInterested.Text} hobisi başarılı bir şekilde güncellenmiştir.", new InterestedsDto
            {
                ResultStatus = ResultStatus.Success,
                Interesteds = updatedInterested,
                Message = $"{updatedInterested.Text} hobisi başarılı bir şekilde güncellenmiştir."
            });
        }
    }
}

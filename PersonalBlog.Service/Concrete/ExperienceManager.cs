using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.ExperiencesDtos;
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
    public class ExperienceManager : IExperienceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ExperienceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<ExperiencesDto>> Add(ExperiencesAddDto experienceAddDto, string createdByName)
        {
            var experience = _mapper.Map<Experiences>(experienceAddDto);
            experience.CreatedByName = createdByName;
            experience.ModifiedByName = createdByName;
            experience.ModifiedTime = DateTime.Now;
            var addedExperience = await _unitOfWork.Experience.AddAsync(experience);
            await _unitOfWork.SaveAsync();
            return new DataResult<ExperiencesDto>(ResultStatus.Success, $"{addedExperience.Title} başlıklı deneyim başarılı bir şekilde kayıt edilmiştir.", new ExperiencesDto
            {
                Experiences = addedExperience,
                Message = $"{addedExperience.Title} başlıklı deneyim başarılı bir şekilde kayıt edilmiştir.",
                ResultStatus = ResultStatus.Success
            });
        }

        public async Task<IResult> Delete(int experienceId, string modifiedByName)
        {
            var experience = await _unitOfWork.Experience.GetAsync(x => x.Id == experienceId);
            if (experience != null)
            {
                experience.ModifiedByName = modifiedByName;
                experience.ModifiedTime = DateTime.Now;
                experience.IsDelete = true;
                await _unitOfWork.Experience.UpdateAsync(experience);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{experience.Title} başlıklı deneyim başarılı bir şekilde slinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<ExperiencesDto>> Get(int experienceId)
        {
            var experience = await _unitOfWork.Experience.GetAsync(x => x.Id == experienceId);
            if (experience != null)
            {
                return new DataResult<ExperiencesDto>(ResultStatus.Success, new ExperiencesDto
                {
                    ResultStatus = ResultStatus.Success,
                    Experiences = experience,

                });
            }
            return new DataResult<ExperiencesDto>(ResultStatus.Error, "Hata, kayıt bulunamdı!", new ExperiencesDto
            {
                ResultStatus = ResultStatus.Error,
                Experiences = null,
                Message = "Hata, kayıt bulunamdı!"
            });
        }

        public async Task<IDataResult<ExperiencesListDto>> GetAll()
        {
            var experiences = await _unitOfWork.Experience.GetAllAsync();
            if (experiences.Count > -1)
            {
                return new DataResult<ExperiencesListDto>(ResultStatus.Success, new ExperiencesListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Experiences = experiences
                });
            }
            return new DataResult<ExperiencesListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new ExperiencesListDto
            {
                Experiences = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<ExperiencesListDto>> GetAllByNonDelete()
        {
            var experiences = await _unitOfWork.Experience.GetAllAsync(x => x.IsDelete == false);
            if (experiences.Count > -1)
            {
                return new DataResult<ExperiencesListDto>(ResultStatus.Success, new ExperiencesListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Experiences = experiences
                });
            }
            return new DataResult<ExperiencesListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new ExperiencesListDto
            {
                Experiences = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<ExperiencesListDto>> GetAllByNonDeleteAndActive()
        {
            var experiences = await _unitOfWork.Experience.GetAllAsync(x => x.IsDelete == false && x.IsActive == true);
            if (experiences.Count > -1)
            {
                return new DataResult<ExperiencesListDto>(ResultStatus.Success, new ExperiencesListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Experiences = experiences
                });
            }
            return new DataResult<ExperiencesListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new ExperiencesListDto
            {
                Experiences = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<ExperiencesUpdateDto>> GetUpdateDto(int experienceId)
        {
            var experience = await _unitOfWork.Experience.GetAsync(x => x.Id == experienceId);
            if (experience != null)
            {
                var experienceUpdateDto = _mapper.Map<ExperiencesUpdateDto>(experience);
                return new DataResult<ExperiencesUpdateDto>(ResultStatus.Success,experienceUpdateDto);
            }
            return new DataResult<ExperiencesUpdateDto>(ResultStatus.Success,"Hata, kayıt bulunamadı!",null);
        }

        public async Task<IResult> HardDelete(int experienceId)
        {
            var experience = await _unitOfWork.Experience.GetAsync(x => x.Id == experienceId);
            if (experience != null)
            {
                await _unitOfWork.Experience.DeleteAsync(experience);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{experience.Title} başlıklı deneyim başarılı bir şekilde veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<ExperiencesDto>> Update(ExperiencesUpdateDto experienceUpdateDto, string modifiedByName)
        {
            var experience = _mapper.Map<Experiences>(experienceUpdateDto);
            experience.ModifiedByName = modifiedByName;
            var updatedExperience = await _unitOfWork.Experience.UpdateAsync(experience);
            await _unitOfWork.SaveAsync();
            return new DataResult<ExperiencesDto>(ResultStatus.Success, $"{updatedExperience.Title} başlıklı deneyim başarılı bir şekilde güncellenmiştir.", new ExperiencesDto
            {
                ResultStatus = ResultStatus.Success,
                Experiences = updatedExperience,
                Message = $"{updatedExperience.Title} başlıklı deneyim başarılı bir şekilde güncellenmiştir."
            });
        }
    }
}

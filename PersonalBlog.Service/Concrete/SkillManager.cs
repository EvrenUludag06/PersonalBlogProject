using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SkillsDtos;
using PersonalBlog.Entities.Dtos.SkilslDtos;
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
    public class SkillManager : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SkillManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<SkillsDto>> Add(SkillsAddDto skillAddDto, string createdByName)
        {
            var skill = _mapper.Map<Skills>(skillAddDto);
            skill.CreatedByName = createdByName;
            skill.ModifiedByName = createdByName;
            skill.ModifiedTime = DateTime.Now;
            var addedSkill = await _unitOfWork.Skill.AddAsync(skill);
            await _unitOfWork.SaveAsync();
            return new DataResult<SkillsDto>(ResultStatus.Success, $"{addedSkill.Title} isimli yetenek başarılı bir şekilde kayıt edilmiştir.", new SkillsDto
            {
                Skills = addedSkill,
                Message = $"{addedSkill.Title} isimli yetenek başarılı bir şekilde kayıt edilmiştir.",
                ResultStatus = ResultStatus.Success
            });
        }

        public async Task<IResult> Delete(int skillId, string modifiedByName)
        {
            var skill = await _unitOfWork.Skill.GetAsync(x => x.Id == skillId);
            if (skill != null)
            {
                skill.IsDelete = true;
                skill.ModifiedByName = modifiedByName;
                skill.ModifiedTime = DateTime.Now;
                await _unitOfWork.Skill.UpdateAsync(skill);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{skill.Title} isimli yetenek başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<SkillsDto>> Get(int skillId)
        {
            var skill = await _unitOfWork.Skill.GetAsync(x => x.Id == skillId);
            if (skill != null)
            {
                return new DataResult<SkillsDto>(ResultStatus.Success, new SkillsDto
                {
                    Skills = skill,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<SkillsDto>(ResultStatus.Error, "Hata, kayıt bulunamadı!", new SkillsDto
            {
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıt bulunamadı!",
                Skills = null
            });
        }

        public async Task<IDataResult<SkillsListDto>> GetAll()
        {
            var skills = await _unitOfWork.Skill.GetAllAsync();
            if (skills.Count > -1)
            {
                return new DataResult<SkillsListDto>(ResultStatus.Success, new SkillsListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Skills = skills
                });
            }
            return new DataResult<SkillsListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new SkillsListDto
            {
                ResultStatus = ResultStatus.Error,
                Skills = skills,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<SkillsListDto>> GetAllByNonDelete()
        {
            var skills = await _unitOfWork.Skill.GetAllAsync(x => x.IsDelete == false);
            if (skills.Count > -1)
            {
                return new DataResult<SkillsListDto>(ResultStatus.Success, new SkillsListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Skills = skills
                });
            }
            return new DataResult<SkillsListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new SkillsListDto
            {
                ResultStatus = ResultStatus.Error,
                Skills = skills,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<SkillsListDto>> GetAllByNonDeleteAndActive()
        {
            var skills = await _unitOfWork.Skill.GetAllAsync(x => x.IsDelete == false && x.IsActive == true);
            if (skills.Count > -1)
            {
                return new DataResult<SkillsListDto>(ResultStatus.Success, new SkillsListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Skills = skills
                });
            }
            return new DataResult<SkillsListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new SkillsListDto
            {
                ResultStatus = ResultStatus.Error,
                Skills = skills,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<SkillsUpdateDto>> GetUpdateDto(int skillId)
        {
            var skill = await _unitOfWork.Skill.GetAsync(x => x.Id == skillId);
            if (skill != null)
            {
                var skillUpdateDto = _mapper.Map<SkillsUpdateDto>(skill);
                return new DataResult<SkillsUpdateDto>(ResultStatus.Success,skillUpdateDto);
            }
            return new DataResult<SkillsUpdateDto>(ResultStatus.Error,"Hata, kayıt bulunamadı!",null);
        }

        public async Task<IResult> HardDelete(int skillId)
        {
            var skill = await _unitOfWork.Skill.GetAsync(x => x.Id == skillId);
            if (skill != null)
            {
                await _unitOfWork.Skill.DeleteAsync(skill);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{skill.Title} isimli yetenek başarılı bir şekilde veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<SkillsDto>> Update(SkillsUpdateDto skillUpdateDto, string modifiedByName)
        {
            var skill = _mapper.Map<Skills>(skillUpdateDto);
            skill.ModifiedByName = modifiedByName;
            var updatedSkill = await _unitOfWork.Skill.UpdateAsync(skill);
            await _unitOfWork.SaveAsync();
            return new DataResult<SkillsDto>(ResultStatus.Success, $"{updatedSkill.Title} isimli yetenek başarılı bir şekilde güncellenmiştir.", new SkillsDto
            {
                ResultStatus = ResultStatus.Success,
                Skills = updatedSkill,
                Message = $"{updatedSkill.Title} isimli yetenek başarılı bir şekilde güncellenmiştir."
            });
        }
    }
}

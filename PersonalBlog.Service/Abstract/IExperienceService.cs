using PersonalBlog.Entities.Dtos.ExperiencesDtos;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Service.Abstract
{
    public interface IExperienceService
    {
        Task<IDataResult<ExperiencesDto>> Get(int experienceId);
        Task<IDataResult<ExperiencesUpdateDto>> GetUpdateDto(int experienceId);
        Task<IDataResult<ExperiencesListDto>> GetAll();
        Task<IDataResult<ExperiencesListDto>> GetAllByNonDelete();
        Task<IDataResult<ExperiencesListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<ExperiencesDto>> Add(ExperiencesAddDto experienceAddDto, string createdByName);
        Task<IDataResult<ExperiencesDto>> Update(ExperiencesUpdateDto experienceUpdateDto, string modifiedByName);
        Task<IResult> Delete(int experienceId, string modifiedByName);
        Task<IResult> HardDelete(int experienceId);
    }
}

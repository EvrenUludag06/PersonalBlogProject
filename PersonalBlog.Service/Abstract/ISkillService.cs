using PersonalBlog.Entities.Dtos.SkillsDtos;
using PersonalBlog.Entities.Dtos.SkilslDtos;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Service.Abstract
{
    public interface ISkillService
    {
        Task<IDataResult<SkillsDto>> Get(int skillId);
        Task<IDataResult<SkillsUpdateDto>> GetUpdateDto(int skillId);
        Task<IDataResult<SkillsListDto>> GetAll();
        Task<IDataResult<SkillsListDto>> GetAllByNonDelete();
        Task<IDataResult<SkillsListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<SkillsDto>> Add(SkillsAddDto skillAddDto, string createdByName);
        Task<IDataResult<SkillsDto>> Update(SkillsUpdateDto skillUpdateDto, string modifiedByName);
        Task<IResult> Delete(int skillId, string modifiedByName);
        Task<IResult> HardDelete(int skillId);
    }
}

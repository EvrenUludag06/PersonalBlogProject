using PersonalBlog.Entities.Dtos.InterestedsDtos;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Service.Abstract
{
    public interface IInterestedsService
    {
        Task<IDataResult<InterestedsDto>> Get(int interestedId);
        Task<IDataResult<InterestedsUpdateDto>> GetUpdateDto(int interestedDto);
        Task<IDataResult<InterestedsListDto>> GetAll();
        Task<IDataResult<InterestedsListDto>> GetAllByNonDelete();
        Task<IDataResult<InterestedsListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<InterestedsDto>> Add(InterestedsAddDto interestedAddDto, string createdByName);
        Task<IDataResult<InterestedsDto>> Update(InterestedsUpdateDto ınterestedUpdateDto, string modifiedByName);
        Task<IResult> Delete(int interestedId, string modifiedByName);
        Task<IResult> HardDelete(int interestedId);
    }
}

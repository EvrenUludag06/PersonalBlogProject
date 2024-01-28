using PersonalBlog.Entities.Dtos.SliderDtos;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Service.Abstract
{
    public interface IHomePageSliderService
    {
        Task<IDataResult<SlidersDto>> Get(int homePageSliderId);
        Task<IDataResult<SlidersUpdateDto>> GetUpdateDto(int homePageSliderId);
        Task<IDataResult<SlidersListDto>> GetAll();
        Task<IDataResult<SlidersListDto>> GetAllByNonDelete();
        Task<IDataResult<SlidersListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<SlidersDto>> Add(SlidersAddDto homePageSliderAddDto, string createdByName);
        Task<IDataResult<SlidersDto>> Update(SlidersUpdateDto homePageSliderUpdateDto, string modifiedByName);
        Task<IResult> Delete(int homePageSliderId, string modifiedByName);
        Task<IResult> HardDelete(int homePageSliderId);
    }
}

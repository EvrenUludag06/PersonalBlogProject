using PersonalBlog.Entities.Dtos.ContactInfoDtos;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Service.Abstract
{
    public interface IContactInfoService
    {
        Task<IDataResult<ContactInfoDto>> Get(int contactInfoId);
        Task<IDataResult<ContactInfoUpdateDto>> GetUpdateDto(int contactInfoId);
        Task<IDataResult<ContactInfoDto>> Update(ContactInfoUpdateDto contactInfoUpdateDto, string modifiedByName);
        Task<IResult> Delete(int contactInfoId, string modifiedByName);
        Task<IResult> HardDelete(int contactInfoId);
    }
}

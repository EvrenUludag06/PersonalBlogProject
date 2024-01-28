using PersonalBlog.Entities.Dtos.SocialMediaAccountDtos;
using PersonalBlog.Shared.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Service.Abstract
{
    public interface ISocialMediaAccountService
    {
        Task<IDataResult<AccountsDto>> Get(int socialMediaAccountId);
        Task<IDataResult<AccountsUpdateDto>> GetUpdateDto(int socialMediaAccountId);
        Task<IDataResult<AccountsListDto>> GetAll();
        Task<IDataResult<AccountsListDto>> GetAllByNonDelete();
        Task<IDataResult<AccountsListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<AccountsDto>> Add(AccountsAddDto socialMediaAccountAddDto, string createdByName);
        Task<IDataResult<AccountsDto>> Update(AccountsUpdateDto socialMediaAccountUpdateDto, string modifiedByName);
        Task<IResult> Delete(int socialMediaAccountId, string modifiedByName);
        Task<IResult> HardDelete(int socialMediaAccountId);
    }
}

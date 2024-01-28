using AutoMapper;
using PersonalBlog.Entities.Dtos.SocialMediaAccountDtos;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
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
    public class SocialMediaAccountManager : ISocialMediaAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SocialMediaAccountManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<AccountsDto>> Add(AccountsAddDto socialMediaAccountAddDto, string createdByName)
        {
            var account = _mapper.Map<SocialMediaAccounts>(socialMediaAccountAddDto);
            account.CreatedByName = createdByName;
            account.ModifiedByName = createdByName;
            account.ModifiedTime = DateTime.Now;
            var addedAccount = await _unitOfWork.SocialMediaAccount.AddAsync(account);
            await _unitOfWork.SaveAsync();
            return new DataResult<AccountsDto>(ResultStatus.Success, "Sosyal medya hesabı başarılı bir şekilde kayıt edilmiştir.", new AccountsDto
            {
                Message = "Sosyal medya hesabı başarılı bir şekilde kayıt edilmiştir.",
                ResultStatus = ResultStatus.Success,
                SocialMediaAccounts = addedAccount
            });
        }

        public async Task<IResult> Delete(int socialMediaAccountId, string modifiedByName)
        {
            var account = await _unitOfWork.SocialMediaAccount.GetAsync(x => x.Id == socialMediaAccountId);
            if (account != null)
            {
                account.IsDelete = true;
                account.ModifiedTime = DateTime.Now;
                account.ModifiedByName = modifiedByName;
                await _unitOfWork.SocialMediaAccount.UpdateAsync(account);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Sosyal medya bilgisi başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kaynak bulunamadı!");
        }

        public async Task<IDataResult<AccountsDto>> Get(int socialMediaAccountId)
        {
            var account = await _unitOfWork.SocialMediaAccount.GetAsync(x => x.Id == socialMediaAccountId);
            if (account != null)
            {
                return new DataResult<AccountsDto>(ResultStatus.Success, new AccountsDto
                {
                    ResultStatus = ResultStatus.Success,
                    SocialMediaAccounts = account
                });
            }
            return new DataResult<AccountsDto>(ResultStatus.Error, "Hata, kayıt bulunamadı!", new AccountsDto
            {
                ResultStatus = ResultStatus.Error,
                SocialMediaAccounts = null,
                Message = "Hata, kayıt bulunamadı!"
            });
        }

        public async Task<IDataResult<AccountsListDto>> GetAll()
        {
            var accounts = await _unitOfWork.SocialMediaAccount.GetAllAsync();
            if (accounts.Count > -1)
            {
                return new DataResult<AccountsListDto>(ResultStatus.Success, new AccountsListDto
                {
                    ResultStatus = ResultStatus.Success,
                    SocialMediaAccounts = accounts
                });
            }
            return new DataResult<AccountsListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new AccountsListDto
            {
                ResultStatus = ResultStatus.Error,
                SocialMediaAccounts = null,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<AccountsListDto>> GetAllByNonDelete()
        {
            var accounts = await _unitOfWork.SocialMediaAccount.GetAllAsync(x => x.IsDelete == false);
            if (accounts.Count > -1)
            {
                return new DataResult<AccountsListDto>(ResultStatus.Success, new AccountsListDto
                {
                    ResultStatus = ResultStatus.Error,
                    SocialMediaAccounts = accounts
                });
            }
            return new DataResult<AccountsListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new AccountsListDto
            {
                ResultStatus = ResultStatus.Error,
                SocialMediaAccounts = null,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<AccountsListDto>> GetAllByNonDeleteAndActive()
        {
            var accounts = await _unitOfWork.SocialMediaAccount.GetAllAsync(x => x.IsDelete == false && x.IsActive == true);
            if (accounts.Count > -1)
            {
                return new DataResult<AccountsListDto>(ResultStatus.Success, new AccountsListDto
                {
                    ResultStatus = ResultStatus.Error,
                    SocialMediaAccounts = accounts
                });
            }
            return new DataResult<AccountsListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new AccountsListDto
            {
                ResultStatus = ResultStatus.Error,
                SocialMediaAccounts = null,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<AccountsUpdateDto>> GetUpdateDto(int socialMediaAccountId)
        {
            var account = await _unitOfWork.SocialMediaAccount.GetAsync(x => x.Id == socialMediaAccountId);
            if (account != null)
            {
                var accountUpdateDto = _mapper.Map<AccountsUpdateDto>(account);
                return new DataResult<AccountsUpdateDto>(ResultStatus.Success, accountUpdateDto);
            }
            return new DataResult<AccountsUpdateDto>(ResultStatus.Error, "Hata, kayıt bulunamadı!", null);
        }

        public async Task<IResult> HardDelete(int socialMediaAccountId)
        {
            var account = await _unitOfWork.SocialMediaAccount.GetAsync(x => x.Id == socialMediaAccountId);
            if (account != null)
            {
                await _unitOfWork.SocialMediaAccount.DeleteAsync(account);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"Sosyal medya hesabı başarılı bir şekilde güncellenmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<AccountsDto>> Update(AccountsUpdateDto socialMediaAccountUpdateDto, string modifiedByName)
        {
            var account = _mapper.Map<SocialMediaAccounts>(socialMediaAccountUpdateDto);
            account.ModifiedByName = modifiedByName;
            var updatedAccount = await _unitOfWork.SocialMediaAccount.UpdateAsync(account);
            await _unitOfWork.SaveAsync();
            return new DataResult<AccountsDto>(ResultStatus.Success, "Sosyal medya hesabı başarılı bir şekilde güncellenmiştir.", new AccountsDto
            {
                ResultStatus = ResultStatus.Success,
                SocialMediaAccounts = updatedAccount,
                Message = "Sosyal medya hesabı başarılı bir şekilde güncellenmiştir."
            });
        }
    }
}

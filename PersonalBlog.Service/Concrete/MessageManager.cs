using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.MessageDtos;
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
    public class MessageManager : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MessageManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<MessageDto>> Add(MessageAddDto messageAddDto, string createdByName)
        {
            var message = _mapper.Map<Messages>(messageAddDto);
            message.CreatedByName = createdByName;
            message.ModifiedByName = createdByName;
            message.ModifiedTime = DateTime.Now;
            var addedMessage = await _unitOfWork.Message.AddAsync(message);
            await _unitOfWork.SaveAsync();
            return new DataResult<MessageDto>(ResultStatus.Success, $"{addedMessage.Subject} konulu mesaj başarılı bir şekilde kayıt edilmiştir.", new MessageDto
            {
                Message = $"{addedMessage.Subject} konulu mesaj başarılı bir şekilde kayıt edilmiştir.",
                Messages = addedMessage,
                ResultStatus = ResultStatus.Success
            });
        }

        public async Task<IResult> CheckMessage(int messageId, string modifiedByName)
        {
            var message = await _unitOfWork.Message.GetAsync(x => x.Id == messageId);
            if (message != null)
            {
                message.IsActive = true;
                message.IsDelete = true;
                message.ModifiedByName = modifiedByName;
                message.ModifiedTime = DateTime.Now;
                await _unitOfWork.Message.UpdateAsync(message);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success,$"{message.Subject} koulu mesaj başarılı bir şekilde onaylanmmıştır.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IResult> Delete(int messageId, string modifiedByName)
        {
            var message = await _unitOfWork.Message.GetAsync(x => x.Id == messageId);
            if (message != null)
            {
                message.IsDelete = true;
                message.ModifiedByName = modifiedByName;
                message.ModifiedTime = DateTime.Now;
                await _unitOfWork.Message.UpdateAsync(message);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{message.Subject} konulu mesaj başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<MessageDto>> Get(int messageId)
        {
            var message = await _unitOfWork.Message.GetAsync(x => x.Id == messageId);
            if (message != null)
            {
                return new DataResult<MessageDto>(ResultStatus.Success, new MessageDto
                {
                    ResultStatus = ResultStatus.Success,
                    Messages = message
                });
            }
            return new DataResult<MessageDto>(ResultStatus.Error, "Hata, kayıt bulunamadı!", new MessageDto
            {
                ResultStatus = ResultStatus.Error,
                Messages = null,
                Message = "Hata, kayıt bulunamadı!"
            });
        }

        public async Task<IDataResult<MessageListDto>> GetAll()
        {
            var messages = await _unitOfWork.Message.GetAllAsync();
            if (messages.Count > -1)
            {
                return new DataResult<MessageListDto>(ResultStatus.Success, new MessageListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Messages = messages
                });
            }
            return new DataResult<MessageListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new MessageListDto
            {
                ResultStatus = ResultStatus.Error,
                Messages = null,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<MessageListDto>> GetAllByNonDelete()
        {
            var messages = await _unitOfWork.Message.GetAllAsync(x => x.IsDelete == false);
            if (messages.Count > -1)
            {
                return new DataResult<MessageListDto>(ResultStatus.Success, new MessageListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Messages = messages
                });
            }
            return new DataResult<MessageListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new MessageListDto
            {
                ResultStatus = ResultStatus.Error,
                Messages = null,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<MessageListDto>> GetAllByNonDeleteAndActive()
        {
            var messages = await _unitOfWork.Message.GetAllAsync(x => x.IsDelete == false && x.IsActive == true);
            if (messages.Count > -1)
            {
                return new DataResult<MessageListDto>(ResultStatus.Success, new MessageListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Messages = messages
                });
            }
            return new DataResult<MessageListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new MessageListDto
            {
                ResultStatus = ResultStatus.Error,
                Messages = null,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<MessageUpdateDto>> GetUpdateDto(int messageId)
        {
            var message = await _unitOfWork.Message.GetAsync(x => x.Id == messageId);
            if (message != null)
            {
                var messageUpdateDto = _mapper.Map<MessageUpdateDto>(message);
                return new DataResult<MessageUpdateDto>(ResultStatus.Success,messageUpdateDto);
            }
            return new DataResult<MessageUpdateDto>(ResultStatus.Error,"Hata, kayıt bulunamadı!",null);
        }

        public async Task<IResult> HardDelete(int messageId)
        {
            var message = await _unitOfWork.Message.GetAsync(x => x.Id == messageId);
            if (message != null)
            {
                await _unitOfWork.Message.DeleteAsync(message);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{message.Subject} konulu mesaj başarılı bir şekilde veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<MessageDto>> Update(MessageUpdateDto messageUpdateDto, string modifiedByName)
        {
            var message = _mapper.Map<Messages>(messageUpdateDto);
            message.ModifiedByName = modifiedByName;
            var updatedMessage = await _unitOfWork.Message.UpdateAsync(message);
            await _unitOfWork.SaveAsync();
            return new DataResult<MessageDto>(ResultStatus.Success, $"{updatedMessage.Subject} konulu mesaj başarılı bir şekilde güncellenmiştir.", new MessageDto
            {
                ResultStatus = ResultStatus.Success,
                Message = $"{updatedMessage.Subject} konulu mesaj başarılı bir şekilde güncellenmiştir.", 
                Messages = updatedMessage
            });
        }
    }
}

using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.SliderDtos;
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
    public class HomePageSliderManager : IHomePageSliderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HomePageSliderManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<SlidersDto>> Add(SlidersAddDto homePageSliderAddDto, string createdByName)
        {
            var slider = _mapper.Map<HomePageSliders>(homePageSliderAddDto);
            slider.CreatedByName = createdByName;
            slider.ModifiedByName = createdByName;
            slider.ModifiedTime = DateTime.Now;
            var addedSlider = await _unitOfWork.HomePageSlider.AddAsync(slider);
            await _unitOfWork.SaveAsync();
            return new DataResult<SlidersDto>(ResultStatus.Success, $"{addedSlider.Title} başlıklı slider başarılı bir şekilde kayıt edilmiştir.", new SlidersDto
            {
                Sliders = addedSlider,
                Message = $"{addedSlider.Title} başlıklı slider başarılı bir şekilde kayıt edilmiştir.",
                ResultStatus = ResultStatus.Success
            });
        }

        public async Task<IResult> Delete(int homePageSliderId, string modifiedByName)
        {
            var slider = await _unitOfWork.HomePageSlider.GetAsync(x => x.Id == homePageSliderId);
            if (slider != null)
            {
                slider.IsDelete = true;
                slider.ModifiedByName = modifiedByName;
                slider.ModifiedTime = DateTime.Now;
                await _unitOfWork.HomePageSlider.UpdateAsync(slider);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{slider.Title} başlıklı slider başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<SlidersDto>> Get(int homePageSliderId)
        {
            var slider = await _unitOfWork.HomePageSlider.GetAsync(x => x.Id == homePageSliderId);
            if (slider != null)
            {
                return new DataResult<SlidersDto>(ResultStatus.Success, new SlidersDto
                {
                    ResultStatus = ResultStatus.Success,
                    Sliders = slider,

                });
            }
            return new DataResult<SlidersDto>(ResultStatus.Error, "Hata, kayıt bulunamadı!", new SlidersDto
            {
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıt bulunamadı!",
                Sliders = null
            });
        }

        public async Task<IDataResult<SlidersListDto>> GetAll()
        {
            var sliders = await _unitOfWork.HomePageSlider.GetAllAsync();
            if (sliders.Count > -1)
            {
                return new DataResult<SlidersListDto>(ResultStatus.Success, new SlidersListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Sliders = sliders,
                });
            }
            return new DataResult<SlidersListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new SlidersListDto
            {
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!",
                Sliders = null
            });
        }

        public async Task<IDataResult<SlidersListDto>> GetAllByNonDelete()
        {
            var sliders = await _unitOfWork.HomePageSlider.GetAllAsync(x => x.IsDelete == false);
            if (sliders.Count > -1)
            {
                return new DataResult<SlidersListDto>(ResultStatus.Success, new SlidersListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Sliders = sliders,
                });
            }
            return new DataResult<SlidersListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new SlidersListDto
            {
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!",
                Sliders = null
            });
        }

        public async Task<IDataResult<SlidersListDto>> GetAllByNonDeleteAndActive()
        {
            var sliders = await _unitOfWork.HomePageSlider.GetAllAsync(x => x.IsDelete == false && x.IsActive == true);
            if (sliders.Count > -1)
            {
                return new DataResult<SlidersListDto>(ResultStatus.Success, new SlidersListDto
                {
                    ResultStatus = ResultStatus.Success,
                    Sliders = sliders,
                });
            }
            return new DataResult<SlidersListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new SlidersListDto
            {
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!",
                Sliders = null
            });
        }

        public async Task<IDataResult<SlidersUpdateDto>> GetUpdateDto(int homePageSliderId)
        {
            var slider = await _unitOfWork.HomePageSlider.GetAsync(x => x.Id == homePageSliderId);
            if (slider != null)
            {
                var sliderUpdateDto = _mapper.Map<SlidersUpdateDto>(slider);
                return new DataResult<SlidersUpdateDto>(ResultStatus.Success,sliderUpdateDto);
            }
            return new DataResult<SlidersUpdateDto>(ResultStatus.Error,"Hata, kayıt bulunamadı!",null);
        }

        public async Task<IResult> HardDelete(int homePageSliderId)
        {
            var slider = await _unitOfWork.HomePageSlider.GetAsync(x => x.Id == homePageSliderId);
            if (slider != null)
            {
                await _unitOfWork.HomePageSlider.DeleteAsync(slider);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{slider.Title} başlıklı slider başarılı bir şekilde veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<SlidersDto>> Update(SlidersUpdateDto homePageSliderUpdateDto, string modifiedByName)
        {
            var slider = _mapper.Map<HomePageSliders>(homePageSliderUpdateDto);
            slider.ModifiedByName = modifiedByName;
            var updatedSlider = await _unitOfWork.HomePageSlider.UpdateAsync(slider);
            await _unitOfWork.SaveAsync();
            return new DataResult<SlidersDto>(ResultStatus.Success, $"{updatedSlider.Title} başlıklı slider başarılı bir şekilde güncellenmiştir.", new SlidersDto
            {
                Sliders = slider,
                ResultStatus = ResultStatus.Success,
                Message = $"{updatedSlider.Title} başlıklı slider başarılı bir şekilde güncellenmiştir."
            });
        }
    }
}

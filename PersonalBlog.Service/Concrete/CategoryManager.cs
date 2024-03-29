﻿using AutoMapper;
using PersonalBlog.Data.Abstract;
using PersonalBlog.Entities.Concrete;
using PersonalBlog.Entities.Dtos.CategoriesDtos;
using PersonalBlog.Entities.Dtos.CategoryDtos;
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
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<Categories>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            category.ModifiedTime = DateTime.Now;
            var addedCategory = await _unitOfWork.Category.AddAsync(category);
            await _unitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, $"{category.Name} isimli kategori başarılı bir şekilde kayıt edilmiştir.", new CategoryDto
            {
                Categories = addedCategory,
                ResultStatus = ResultStatus.Success,
                Message = $"{category.Name} isimli kategori başarılı bir şekilde kayıt edilmiştir."
            });
        }

        public async Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Category.GetAsync(x => x.Id == categoryId);
            if (category != null)
            {
                category.ModifiedByName = modifiedByName;
                category.IsDelete = true;
                category.ModifiedTime = DateTime.Now;
                await _unitOfWork.Category.UpdateAsync(category);
                return new Result(ResultStatus.Success, $"{category.Name} isimli kategori başarılı bir şekilde silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Category.GetAsync(x => x.Id == categoryId);
            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Categories = category,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Hata, kayıt bulunamadı!", new CategoryDto
            {
                ResultStatus = ResultStatus.Error,
                Categories = null,
                Message = "Hata, kayıt bulunamadı!"
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Category.GetAllAsync();
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success,

                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDelete()
        {
            var categories = await _unitOfWork.Category.GetAllAsync(x => x.IsDelete == false);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success,

                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleteAndActive()
        {
            var categories = await _unitOfWork.Category.GetAllAsync(x => x.IsDelete == false && x.IsActive == true);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hata, kayıtlar bulunamadı!", new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hata, kayıtlar bulunamadı!"
            });
        }

        public async Task<IDataResult<CategoryUpdateDto>> GetUpdateDto(int categoryId)
        {
            var category = await _unitOfWork.Category.GetAsync(x => x.Id == categoryId);
            if (category != null)
            {
                var categoryUpdateDto = _mapper.Map<CategoryUpdateDto>(category);
                return new DataResult<CategoryUpdateDto>(ResultStatus.Success,categoryUpdateDto);
            }
            return new DataResult<CategoryUpdateDto>(ResultStatus.Error,"Hata, kayıt bulunamadı!",null);
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Category.GetAsync(x => x.Id == categoryId);
            if (category != null)
            {
                await _unitOfWork.Category.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{category.Name} isimli kategori başarılı bir şekilde veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Hata, kayıt bulunamadı!");
        }

        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = _mapper.Map<Categories>(categoryUpdateDto);
            category.ModifiedByName = modifiedByName;
            var updatedCategory = await _unitOfWork.Category.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
            {
                Categories = updatedCategory,
                ResultStatus = ResultStatus.Success
            });
        }
    }
}

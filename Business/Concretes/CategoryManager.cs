using Business.Abstracts;
using Business.Validations;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using DataAccess.Abstracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Business.Concretes;

public class CategoryManager : ICategoryService
{
    public readonly ICategoryRepository _categoryRepository;
    public readonly CategoryValidations _categoryValidations;

    public CategoryManager(ICategoryRepository categoryRepository, CategoryValidations categoryValidations)
    {
        _categoryRepository = categoryRepository;
        _categoryValidations = categoryValidations;
    }

    public Category Add(Category category)
    {
        return _categoryRepository.Add(category);
    }

    [DebugWriteSuccessAspect(Message = "Category added.")]
    public async Task<Category> AddAsync(Category category)
    {
        return await _categoryRepository.AddAsync(category);
    }

    [ValidationAspect(typeof(DeleteCategoryValidations))]
    public void DeleteById(Guid id)
    {
        var category = _categoryRepository.Get(c => c.Id == id);
        _categoryRepository.Delete(category);
    }

    [ValidationAspect(typeof(DeleteCategoryValidations))]
    [DebugWriteSuccessAspect(Message = "Category deleted.")]
    public async Task DeleteByIdAsync(Guid id)
    {
        var category = _categoryRepository.Get(c => c.Id == id);
        await _categoryRepository.DeleteAsync(category);
    }

    [DebugWriteAspect(Message = "Category listing started")]
    [DebugWriteSuccessAspect(Message = "Category listing completed.")]
    public IList<Category> GetAll()
    {
        return _categoryRepository.GetAll().ToList();
    }

    [DebugWriteAspect(Message = "Category listing started")]
    [DebugWriteSuccessAspect(Message = "Category listing completed.")]
    public async Task<IList<Category>> GetAllAsync()
    {
        var result = await _categoryRepository.GetAllAsync();
        return result.ToList();
    }

    public IList<Category> GetAllWithProducts()
    {
        return _categoryRepository.GetAll(include: category => category.Include(c => c.Products)).ToList();

    }

    public async Task<IList<Category>> GetAllWithProductsAsync()
    {
        var result = await _categoryRepository.GetAllAsync(include: category => category.Include(c => c.Products));
        return result.ToList();
    }

    [ValidationAspect(typeof(CategoryValidations))]
    public Category? GetById(Guid id)
    {
        return _categoryRepository.Get(c => c.Id == id);
    }

    [ValidationAspect(typeof(CategoryValidations))]
    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _categoryRepository.GetAsync(c => c.Id == id);
    }

    public Category Update(Category category)
    {
        return _categoryRepository.Update(category);
    }

    [DebugWriteSuccessAspect(Message = "Category updated.")]
    public async Task<Category> UpdateAsync(Category category)
    {
        return await _categoryRepository.UpdateAsync(category);
    }
}

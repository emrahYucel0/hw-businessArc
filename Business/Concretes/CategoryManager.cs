using Business.Abstracts;
using Business.Validations;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public async Task<Category> AddAsync(Category category)
    {
        return await _categoryRepository.AddAsync(category);
    }

    public void DeleteById(Guid id)
    {
        var category = _categoryRepository.Get(c => c.Id == id);
        _categoryValidations.CategoryMustNotBeEmpty(category).Wait();
        _categoryRepository.Delete(category);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var category = _categoryRepository.Get(c => c.Id == id);
        await _categoryValidations.CategoryMustNotBeEmpty(category);
        await _categoryRepository.DeleteAsync(category);
    }

    public IList<Category> GetAll()
    {
        return _categoryRepository.GetAll().ToList();
    }

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

    public Category? GetById(Guid id)
    {
        return _categoryRepository.Get(c => c.Id == id);
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _categoryRepository.GetAsync(c => c.Id == id);
    }

    public Category Update(Category category)
    {
        return _categoryRepository.Update(category);
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        return await _categoryRepository.UpdateAsync(category);
    }
}

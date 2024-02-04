using Business.Abstracts;
using Business.Validations;
using DataAccess.Abstracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class CardManager:ICardService
{
    public readonly ICardRepository _cardRepository;
    public readonly CardValidations _cardValidations;

    public CardManager(ICardRepository cardRepository, CardValidations cardValidations)
    {
        _cardRepository = cardRepository;
        _cardValidations = cardValidations;
    }
    public Card Add(Card card)
    {
        return _cardRepository.Add(card);
    }

    public async Task<Card> AddAsync(Card card)
    {
        return await _cardRepository.AddAsync(card);
    }

    public void DeleteById(Guid id)
    {
        var card = _cardRepository.Get(c => c.Id == id);
        _cardValidations.CardMustNotBeEmpty(card).Wait();
        _cardRepository.Delete(card);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var card = _cardRepository.Get(c => c.Id == id);
        await _cardValidations.CardMustNotBeEmpty(card);
        await _cardRepository.DeleteAsync(card);
    }

    public IList<Card> GetAll()
    {
        return _cardRepository.GetAll().ToList();
    }

    public async Task<IList<Card>> GetAllAsync()
    {
        var result = await _cardRepository.GetAllAsync();
        return result.ToList();
    }

    public IList<Card> GetAllWithUser()
    {
        return _cardRepository.GetAll(include: card => card.Include(c => c.User)).ToList();
    }

    public async Task<IList<Card>> GetAllWithUserAsync()
    {
        var result = await _cardRepository.GetAllAsync(include: card => card.Include(c => c.User));
        return result.ToList();
    }

    public IList<Card> GetAllWithCardType()
    {
        return _cardRepository.GetAll(include: card => card.Include(c => c.CardType)).ToList();
    }

    public async Task<IList<Card>> GetAllWithCardTypeAsync()
    {
        var result = await _cardRepository.GetAllAsync(include: card => card.Include(c => c.CardType));
        return result.ToList();
    }

    public Card? GetById(Guid id)
    {
        return _cardRepository.Get(c => c.Id == id);
    }

    public async Task<Card?> GetByIdAsync(Guid id)
    {
        return await _cardRepository.GetAsync(c => c.Id == id);
    }

    public Card Update(Card card)
    {
        return _cardRepository.Update(card);
    }

    public async Task<Card> UpdateAsync(Card card)
    {
        return await _cardRepository.UpdateAsync(card);
    }
}

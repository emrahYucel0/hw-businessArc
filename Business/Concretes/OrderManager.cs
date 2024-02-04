using Business.Abstracts;
using Business.Validations;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class OrderManager : IOrderService
{
    public readonly IOrderRepository _orderRepository;
    public readonly OrderValidations _orderValidations;

    public OrderManager(IOrderRepository orderRepository, OrderValidations orderValidations)
    {
        _orderRepository = orderRepository;
        _orderValidations = orderValidations;
    }
    public Order Add(Order order)
    {
        return _orderRepository.Add(order);
    }

    public async Task<Order> AddAsync(Order order)
    {
        return await _orderRepository.AddAsync(order);
    }

    public void DeleteById(Guid id)
    {
        var order = _orderRepository.Get(o => o.Id == id);
        _orderValidations.OrderMustNotBeEmpty(order).Wait();
        _orderRepository.Delete(order);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var order = _orderRepository.Get(o => o.Id == id);
        await _orderValidations.OrderMustNotBeEmpty(order);
        await _orderRepository.DeleteAsync(order);
    }

    public IList<Order> GetAll()
    {
        return _orderRepository.GetAll().ToList();
    }

    public async Task<IList<Order>> GetAllAsync()
    {
        var result = await _orderRepository.GetAllAsync();
        return result.ToList();
    }

    public Order? GetById(Guid id)
    {
        return _orderRepository.Get(o => o.Id == id);
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _orderRepository.GetAsync(o => o.Id == id);
    }

    public Order Update(Order order)
    {
        return _orderRepository.Update(order);
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        return await _orderRepository.UpdateAsync(order);
    }
}

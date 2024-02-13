using Business.Abstracts;
using Business.Validations;
using Core.Aspects.Autofac.Transaction;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class OrderManager : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly OrderValidations _orderValidations;
    private readonly IProductTransactionService _productTransactionService;
    private readonly IOrderDetailService _orderDetailService;

    public OrderManager(
        IOrderRepository orderRepository, 
        OrderValidations orderValidations, 
        IProductTransactionService productTransactionService,
        IOrderDetailService orderDetailService
        )
    {
        _orderRepository = orderRepository;
        _orderValidations = orderValidations;
        _productTransactionService = productTransactionService;
        _orderDetailService = orderDetailService;
    }
    public Order Add(AddOrderDto addOrderDto)
    {
        _orderValidations.CheckProductListCount(addOrderDto);
        _orderValidations.CheckTransactionCount(addOrderDto);
        _orderValidations.CheckStock(addOrderDto);

        var addedOrder = _orderRepository.Add(new()
        {
            UserId = addOrderDto.UserId,
            CreatedDate = DateTime.UtcNow
        });

        addOrderDto.ProductTransactions.ToList().ForEach(productTransaction =>
        {
            productTransaction.Quantity = productTransaction.Quantity > 0 ? -1 * productTransaction.Quantity : productTransaction.Quantity;
            var addedProductTransaction = _productTransactionService.Add(productTransaction);
            _orderDetailService.Add(new()
            {
                OrderId = addedOrder.Id,
                ProductId = productTransaction.ProductId,
                ProductTransactionId = addedProductTransaction.Id
            });
        });
        return addedOrder;
    }
    [TransactionScopeAspect]
    public async Task<Order> AddAsync(AddOrderDto addOrderDto)
    {
        await _orderValidations.CheckProductListCount(addOrderDto);
        await _orderValidations.CheckTransactionCount(addOrderDto);
        await _orderValidations.CheckStock(addOrderDto);

        var addedOrder = await _orderRepository.AddAsync(new()
        {
            UserId = addOrderDto.UserId,
            CreatedDate = DateTime.UtcNow
        });

        addOrderDto.ProductTransactions.ToList().ForEach(productTransaction =>
        {
            productTransaction.Quantity = productTransaction.Quantity > 0 ? -1 * productTransaction.Quantity : productTransaction.Quantity;
            var addedProductTransaction = _productTransactionService.Add(productTransaction);
            _orderDetailService.Add(new()
            {
                OrderId = addedOrder.Id,
                ProductId = productTransaction.ProductId,
                ProductTransactionId = addedProductTransaction.Id
            });
        });
        return addedOrder;
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
    [TransactionScopeAspect]
    public async Task<Order> UpdateAsync(Order order)
    {
        return await _orderRepository.UpdateAsync(order);
    }
}

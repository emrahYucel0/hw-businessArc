using Core.Repository;
using DataAccess.Abstracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(DbContext context) : base(context)
    {
    }
}

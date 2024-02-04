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

public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
{
    public OrderDetailRepository(DbContext context) : base(context)
    {
    }
}

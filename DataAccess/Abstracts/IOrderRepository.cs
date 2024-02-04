﻿using Core.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts;

public interface IOrderRepository:IAsyncRepository<Order>,IRepository<Order>
{
}

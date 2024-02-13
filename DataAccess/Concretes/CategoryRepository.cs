using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(BusinessDbContext context) : base(context)
    {
    }
}

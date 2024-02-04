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

public class CardRepository : Repository<Card>, ICardRepository
{
    public CardRepository(DbContext context) : base(context)
    {
    }
}

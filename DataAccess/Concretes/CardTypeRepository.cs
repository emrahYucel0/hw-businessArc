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

public class CardTypeRepository : Repository<CardType>, ICardTypeRepository
{
    public CardTypeRepository(DbContext context) : base(context)
    {
    }
}

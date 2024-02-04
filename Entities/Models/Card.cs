using Core.Entities;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models;

public class Card:Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid CardTypeId { get; set; }
    public long CardUID { get; set; }
    public decimal Limit { get; set; }
    public virtual User User { get; set; }
    public virtual CardType CardType { get; set; }
}

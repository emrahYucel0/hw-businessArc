using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models;

public class AccountTransaction:Entity<Guid>
{
    public Guid CardId { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreatedDate { get; set; }
    public virtual Card Card { get; set; }
}

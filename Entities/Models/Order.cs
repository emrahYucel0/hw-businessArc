using Core.Entities;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models;

public class Order : Entity<Guid>
{
    public Guid UserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    public Order()
    {
        OrderDetails = new HashSet<OrderDetail>();
    }
}

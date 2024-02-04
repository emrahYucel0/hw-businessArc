using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models;

public class CardType:Entity<Guid>
{
    public string Name { get; set; } //Mifare , Mifare 4k,RFID

}

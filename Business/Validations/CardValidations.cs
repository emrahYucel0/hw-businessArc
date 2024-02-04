using Business.Tools.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;

public class CardValidations
{
    public async Task CardMustNotBeEmpty(Card? card)
    {
        if (card == null)
        {
            throw new ValidationException("Card must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}

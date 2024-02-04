using Business.Tools.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;

public class OrderValidations
{
    public async Task OrderMustNotBeEmpty(Order? order)
    {
        if (order == null)
        {
            throw new ValidationException("Order must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}

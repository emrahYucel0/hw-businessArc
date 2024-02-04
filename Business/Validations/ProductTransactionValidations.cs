using Business.Tools.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;

public class ProductTransactionValidations
{
    public async Task ProductTransactionMustNotBeEmpty(ProductTransaction? productTransaction)
    {
        if (productTransaction == null)
        {
            throw new ValidationException("Product Transaction must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}

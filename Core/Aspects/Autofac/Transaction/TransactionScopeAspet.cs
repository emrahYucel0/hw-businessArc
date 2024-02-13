﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Transaction;

public class TransactionScopeAspect : MethodInterception
{
    public override void Intercept(IInvocation invocation)
    {

        using (var transaction = new TransactionScope())
        {
            try
            {
                invocation.Proceed();
                transaction.Complete();
            }
            catch (Exception e)
            {
                transaction.Dispose();
                throw;
            }
        }
    }
}

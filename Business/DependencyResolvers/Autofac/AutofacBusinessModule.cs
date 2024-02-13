using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Autofac;
using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Module = Autofac.Module;
using Business.Validations;


namespace Business.DependencyResolvers.Autofac;
public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<JWTTokenHelper>().As<ITokenHelper>();

        builder.RegisterType<ClaimRepository>().As<IClaimRepository>();
        builder.RegisterType<ClaimValidations>();
        builder.RegisterType<ClaimManager>().As<IClaimService>();
        builder.RegisterType<UserClaimRepository>().As<IUserClaimRepository>();

        builder.RegisterType<UserValidations>();
        builder.RegisterType<UserRepository>().As<IUserRepository>();
        builder.RegisterType<UserManager>().As<IUserService>();

        builder.RegisterType<CategoryValidations>();
        builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
        builder.RegisterType<CategoryManager>().As<ICategoryService>();

        builder.RegisterType<ProductValidations>();
        builder.RegisterType<ProductRepository>().As<IProductRepository>();
        builder.RegisterType<ProductManager>().As<IProductService>();

        builder.RegisterType<ProductTransactionValidations>();
        builder.RegisterType<ProductTransactionRepository>().As<IProductTransactionRepository>();
        builder.RegisterType<ProductTransactionManager>().As<IProductTransactionService>();

        builder.RegisterType<OrderValidations>();
        builder.RegisterType<OrderRepository>().As<IOrderRepository>();
        builder.RegisterType<OrderManager>().As<IOrderService>();

        builder.RegisterType<OrderDetailValidations>();
        builder.RegisterType<OrderDetailRepository>().As<IOrderDetailRepository>();
        builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>();

        builder.RegisterType<CardValidations>();
        builder.RegisterType<CardRepository>().As<ICardRepository>();
        builder.RegisterType<CardManager>().As<ICardService>();

        builder.RegisterType<CardTypeValidations>();
        builder.RegisterType<CardTypeRepository>().As<ICardTypeRepository>();
        builder.RegisterType<CardTypeManager>().As<ICardTypeService>();

        builder.RegisterType<AuthValidations>();
        builder.RegisterType<AuthManager>().As<IAuthService>();

        var assembly = Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();

    }
}

using System;
using Business.Abstracts;
using Business.Concretes;
using Business.Validations;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class ServiceRegistration
{
	public static void RegisterBusinessServices(this IServiceCollection services)
	{
		services.AddDbContext<BusinessDbContext>();
		services.AddSingleton<ITokenHelper, JWTTokenHelper>();
		services.AddScoped<IClaimRepository, ClaimRepository>();
		services.AddScoped<ClaimValidations>();
		services.AddScoped<IClaimService, ClaimManager>();
		services.AddScoped<IUserClaimRepository, UserClaimRepository>();
		services.AddScoped<UserValidations>();
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IUserService, UserManager>();
		services.AddScoped<CategoryValidations>();
		services.AddScoped<ICategoryRepository,CategoryRepository>();
		services.AddScoped<ICategoryService,CategoryManager>();
        services.AddScoped<ProductValidations>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<ProductTransactionValidations>();
        services.AddScoped<IProductTransactionRepository, ProductTransactionRepository>();
        services.AddScoped<IProductTransactionService, ProductTransactionManager>();
        services.AddScoped<OrderValidations>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, OrderManager>();
        services.AddScoped<OrderDetailValidations>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IOrderDetailService, OrderDetailManager>();
        services.AddScoped<CardValidations>();
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<ICardService, CardManager>();
        services.AddScoped<CardTypeValidations>();
        services.AddScoped<ICardTypeRepository, CardTypeRepository>();
        services.AddScoped<ICardTypeService, CardTypeManager>();
        services.AddScoped<AuthValidations>();
		services.AddScoped<IAuthService, AuthManager>();
    }
}


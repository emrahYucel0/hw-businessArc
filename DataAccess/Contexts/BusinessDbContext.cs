using System;
using Core.Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Contexts;

public class BusinessDbContext:DbContext
{
    protected IConfiguration Configuration;
    public BusinessDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Configuration.GetValue<string>("ConnectionStrings:Production");
        optionsBuilder.UseSqlServer(connectionString);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<CardType> CardTypes { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<ProductTransaction> ProductTransactions { get; set; }
    public DbSet<AccountTransaction> AccountTransactions { get; set; }
}


using Grocery.Api.Constants;
using Grocery.Api.Data;
using Grocery.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString(DatabaseConstants.ConnectionStringKey)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var masterGroup = app.MapGroup("/masters").AllowAnonymous();

masterGroup.MapGet("/categories", async (DataContext context) =>
    TypedResults.Ok(await context.Categories.AsNoTracking().ToArrayAsync())
);

masterGroup.MapGet("/offers", async (DataContext context) =>
    TypedResults.Ok(await context.Offers.AsNoTracking().ToArrayAsync())
);

app.MapGet("/popular-products", async (DataContext context,int? count) =>
    {
        if (!count.HasValue || count <= 0)
            count = 6;
        var randomProducts = await context.Products
        .AsNoTracking()
        .OrderBy(p => Guid.NewGuid())
        .Take(count.Value)
        .Select(Product.DtoSelector)
        .ToArrayAsync();
        return TypedResults.Ok(randomProducts);
    }
);


app.Run("https://localhost:12345");

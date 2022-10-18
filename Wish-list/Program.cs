using Microsoft.EntityFrameworkCore;
using Wish_list.Core.Interfaces;
using Wish_list.Core.Models;
using Wish_list.Core.Models.WishValidators;
using Wish_list.Core.Services;
using Wish_list.Data;
using Wish_list.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WishListDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("wish-list"));
});

builder.Services.AddScoped<IWishListDbContext, WishListDbContext>();

builder.Services.AddScoped<IEntityService<Wish>, EntityService<Wish>>();

builder.Services.AddScoped<IWishValidator, WishNameValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
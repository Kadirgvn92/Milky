using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Milky.BusinessLayer.Extensions;
using Milky.DataAccessLayer.Context;
using Milky.Entity.Concrete;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MilkyContext>();

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<MilkyContext>()
    .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);


builder.Services.ContainerDependencies();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();

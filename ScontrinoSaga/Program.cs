using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.AspNetCore.Components.Web;
using ScontrinoSaga.Data;
using ScontrinoSaga;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//builder.Services.AddSingleton<WeatherForecastService>();
SagaConfig cfg = builder.Configuration.GetSection("Saga").Get<SagaConfig>() ?? new SagaConfig();

builder.Services.AddSingleton(cfg);

builder.Services.AddDbContextFactory<AppDBContext>(opt=>opt.UseSqlite(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

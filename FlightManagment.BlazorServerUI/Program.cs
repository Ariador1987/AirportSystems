using Blazored.LocalStorage;
using FlightManagment.BlazorServerUI.Data;
using FlightManagment.BlazorServerUI.Providers;
using FlightManagment.BlazorServerUI.Services;
using FlightManagment.Configurations.MapperConfig;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpClient();
builder.Services.AddScoped<JwtSecurityTokenHandler>();
builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(x =>
{
    return x.GetRequiredService<ApiAuthenticationStateProvider>();
});
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<AirportService>();
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<PassengersService>();
builder.Services.AddScoped<FlightService>();
builder.Services.AddAutoMapper(typeof(MapperConfig));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
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

using Microsoft.EntityFrameworkCore;
using PrioridadesLor.BLL;
using PrioridadesLor.Components;
using PrioridadesLor.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



builder.Services.AddDbContext<Contexto>(options => options.UseSqlite("Data Source=Propiedades.db"));
builder.Services.AddScoped<PrioridadesService>();
builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<SistemasService>();
builder.Services.AddScoped<TicketsService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

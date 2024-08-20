using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Infra.Compartilhado;
using LocadoraDeCarros.Infra.ModuloGrupoAutomoveis;
using GrupoAutomoveis = LocadoraDeCarros.Infra.Migrations.GrupoAutomoveis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Injecao de dependencias

builder.Services.AddDbContext<LocadoraDeCarrosDbContext>();
builder.Services.AddScoped<IRepositorioGrupoAutomoveis,RepositorioGrupoAutomoveis>();

#endregion



var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
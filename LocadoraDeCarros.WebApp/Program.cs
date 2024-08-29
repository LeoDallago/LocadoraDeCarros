using System.Reflection;
using LocadoraDeCarros.Aplicacao;
using LocadoraDeCarros.Aplicacao.Servicos;
using LocadoraDeCarros.Dominio.ModuloAluguel;
using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Dominio.ModuloConfiguracoes;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Dominio.ModuloPlanos;
using LocadoraDeCarros.Dominio.ModuloTaxa;
using LocadoraDeCarros.Infra.Compartilhado;
using LocadoraDeCarros.Infra.ModuloAluguel;
using LocadoraDeCarros.Infra.ModuloAutomovel;
using LocadoraDeCarros.Infra.ModuloCliente;
using LocadoraDeCarros.Infra.ModuloCondutor;
using LocadoraDeCarros.Infra.ModuloConfiguracoes;
using LocadoraDeCarros.Infra.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Infra.ModuloPlanos;
using LocadoraDeCarros.Infra.ModuloTaxa;
using Microsoft.Data.SqlClient;
using GrupoAutomoveis = LocadoraDeCarros.Infra.Migrations.Initial;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Injecao de dependencias

builder.Services.AddDbContext<LocadoraDeCarrosDbContext>();
builder.Services.AddScoped<IRepositorioGrupoAutomoveis,RepositorioGrupoAutomoveis>();
builder.Services.AddScoped<IRepositorioAutomovel, RepositorioAutomovel>();
builder.Services.AddScoped<IRepositorioPlanos, RepositorioPlanos>();
builder.Services.AddScoped<IRepositorioTaxa, RepositorioTaxa>();
builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
builder.Services.AddScoped<IRepositorioCondutor, RepositorioCondutor>();
builder.Services.AddScoped<IRepositorioConfiguracoes, RepositorioConfiguracoes>();
builder.Services.AddScoped<IRepositorioAluguel, RepositorioAluguel>();

builder.Services.AddScoped<GrupoAutomoveisService>();
builder.Services.AddScoped<AutomoveisService>();
builder.Services.AddScoped<PlanosService>();
builder.Services.AddScoped<TaxaService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<CondutorService>();
builder.Services.AddScoped<ConfiguracoesService>();
builder.Services.AddScoped<AluguelService>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(Assembly.GetExecutingAssembly());
});
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
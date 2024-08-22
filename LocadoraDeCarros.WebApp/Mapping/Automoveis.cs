using AutoMapper;
using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class Automoveis : Profile
{
    public Automoveis()
    {
        CreateMap<InserirAutomovelViewModel, Automovel>();
        CreateMap<EditarAutomovelViewModel, Automovel>();

        CreateMap<Automovel, EditarAutomovelViewModel>();
        CreateMap<Automovel, ListarAutomovelViewModel>();
        CreateMap<Automovel, DetalhesAutomovelViewModel>();
    }
}
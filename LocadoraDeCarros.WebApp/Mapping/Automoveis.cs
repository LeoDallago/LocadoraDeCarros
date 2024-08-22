using AutoMapper;
using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class Automoveis : Profile
{
    public Automoveis()
    {
        CreateMap<InserirAutomovelViewModel, Automovel>()
            .ForMember(dest => dest.Foto, opt => opt.Ignore());
        CreateMap<EditarAutomovelViewModel, Automovel>();

        CreateMap<Automovel, EditarAutomovelViewModel>();
        CreateMap<Automovel, ListarAutomovelViewModel>();
        CreateMap<Automovel, DetalhesAutomovelViewModel>();
    }
}
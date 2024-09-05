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
        CreateMap<EditarAutomovelViewModel, Automovel>()
            .ForMember(dest => dest.Foto, opt => opt.Ignore());
        CreateMap<Automovel, EditarAutomovelViewModel>();
        CreateMap<Automovel, ListarAutomovelViewModel>()
            .ForMember(dest => dest.Grupo, opt => opt.MapFrom(c => c.Grupo!.Grupo));
        CreateMap<Automovel, DetalhesAutomovelViewModel>()
            .ForMember(dest => dest.Grupo, opt => opt.MapFrom(c => c.Grupo!.Grupo));
    }
}
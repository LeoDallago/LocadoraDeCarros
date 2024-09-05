using AutoMapper;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class Aluguel : Profile
{
    public Aluguel()
    {
        CreateMap<InserirAluguelViewModel, Dominio.ModuloAluguel.Aluguel>();
        CreateMap<EditarAluguelViewModel, Dominio.ModuloAluguel.Aluguel>();

        CreateMap<Dominio.ModuloAluguel.Aluguel, EditarAluguelViewModel>();
        CreateMap<Dominio.ModuloAluguel.Aluguel, ListarAluguelViewModel>()
            .ForMember(dest => dest.Automovel, opt => opt.MapFrom(c => c.Automovel!.Modelo))
            .ForMember(dest => dest.Condutor, opt => opt.MapFrom(c => c.Condutor!.Nome))
            .ForMember(dest => dest.Plano, opt => opt.MapFrom(c => c.Plano!.Plano))
            .ForMember(dest => dest.Taxa, opt => opt.MapFrom(c => c.Taxa!.Nome));
        CreateMap<Dominio.ModuloAluguel.Aluguel, DetalhesAluguelViewModel>()
            .ForMember(dest => dest.Automovel, opt => opt.MapFrom(c => c.Automovel!.Modelo))
            .ForMember(dest => dest.Condutor, opt => opt.MapFrom(c => c.Condutor!.Nome))
            .ForMember(dest => dest.Plano, opt => opt.MapFrom(c => c.Plano!.Plano))
            .ForMember(dest => dest.Taxa, opt => opt.MapFrom(c => c.Taxa!.Nome));
    }
}
using AutoMapper;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class Planos : Profile
{
    public Planos()
    {
        CreateMap<InserirPlanoViewModel, Dominio.ModuloPlanos.Planos>();
        CreateMap<EditarPlanoViewModel, Dominio.ModuloPlanos.Planos>();

        CreateMap<Dominio.ModuloPlanos.Planos, EditarPlanoViewModel>();
        CreateMap<Dominio.ModuloPlanos.Planos, ListarPlanoViewModel>();
        CreateMap<Dominio.ModuloPlanos.Planos, DetalhesPlanoViewModel>();
    }
}
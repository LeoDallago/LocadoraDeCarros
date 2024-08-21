using AutoMapper;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class GrupoAutomoveis : Profile
{
    public GrupoAutomoveis()
    {
        CreateMap<InserirGrupoAutomoveisViewModel, Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis>();
        CreateMap<EditarGrupoAutomoveisViewModel, Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis>();

        CreateMap<Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis, EditarGrupoAutomoveisViewModel>();
        CreateMap<Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis, ListarGrupoAutomoveisViewModel>();
        CreateMap<Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis, DetalhesGrupoAutomoveisViewModel>();
    }
}
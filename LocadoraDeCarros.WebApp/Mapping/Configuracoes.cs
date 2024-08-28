using AutoMapper;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class Configuracoes : Profile
{
    public Configuracoes()
    {
        CreateMap<ConfiguracoesViewModel, Dominio.ModuloConfiguracoes.Configuracoes>();
        CreateMap<Dominio.ModuloConfiguracoes.Configuracoes, ConfiguracoesViewModel>();
    }
}
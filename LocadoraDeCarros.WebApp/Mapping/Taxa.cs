using AutoMapper;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class Taxa : Profile
{
    public Taxa()
    {
        CreateMap<InserirTaxaViewModel, Dominio.ModuloTaxa.Taxa>();
        CreateMap<EditarTaxaViewModel, Dominio.ModuloTaxa.Taxa>();

        CreateMap<Dominio.ModuloTaxa.Taxa, EditarTaxaViewModel>();
        CreateMap<Dominio.ModuloTaxa.Taxa, ListarTaxaViewModel>();
    }
}
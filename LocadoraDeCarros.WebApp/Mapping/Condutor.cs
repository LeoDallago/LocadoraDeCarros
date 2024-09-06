using AutoMapper;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class Condutor : Profile
{
    public Condutor()
    {
        CreateMap<InserirCondutorViewModel, Dominio.ModuloCondutor.Condutor>();
        CreateMap<EditarCondutorViewModel, Dominio.ModuloCondutor.Condutor>();

        CreateMap<Dominio.ModuloCondutor.Condutor, EditarCondutorViewModel>();
        CreateMap<Dominio.ModuloCondutor.Condutor, ListarCondutorViewModel>();
        CreateMap<Dominio.ModuloCondutor.Condutor, DetalhesCondutorViewModel>();
    }
}
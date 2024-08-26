using AutoMapper;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class Cliente : Profile
{
    public Cliente()
    {
        CreateMap<InserirClienteViewModel, Dominio.ModuloCliente.Cliente>();
        CreateMap<EditarClienteViewModel, Dominio.ModuloCliente.Cliente>();

        CreateMap<Dominio.ModuloCliente.Cliente, EditarClienteViewModel>();
        CreateMap<Dominio.ModuloCliente.Cliente, ListarClienteViewModel>();
        CreateMap<Dominio.ModuloCliente.Cliente, DetalhesClienteViewModel>();
    }
}
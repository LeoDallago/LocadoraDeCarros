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
        CreateMap<Dominio.ModuloAluguel.Aluguel, ListarAluguelViewModel>();
        CreateMap<Dominio.ModuloAluguel.Aluguel, DetalhesAluguelViewModel>();
    }
}
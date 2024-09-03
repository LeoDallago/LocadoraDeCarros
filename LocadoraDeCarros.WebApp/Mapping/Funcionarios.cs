using AutoMapper;
using LocadoraDeCarros.Dominio.ModuloFuncionario;
using LocadoraDeCarros.WebApp.Models;

namespace LocadoraDeCarros.WebApp.Mapping;

public class Funcionarios : Profile
{
    public Funcionarios()
    {
        CreateMap<InserirFuncionarioViewModel, Funcionario>();
        CreateMap<EditarFuncionarioViewModel, Funcionario>();

        CreateMap<Funcionario, EditarFuncionarioViewModel>();
        CreateMap<Funcionario, ListarFuncionarioViewModel>();
    }
}
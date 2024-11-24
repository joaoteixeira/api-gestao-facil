using ApiGestaoFacil.Dtos;
using ApiGestaoFacil.Models;
using AutoMapper;

namespace ApiGestaoFacil.DataContexts;

public class AutoMapperProfile : Profile
{
  public AutoMapperProfile()
  {
    CreateMap<ServidorDto, Servidor>();
  }
}
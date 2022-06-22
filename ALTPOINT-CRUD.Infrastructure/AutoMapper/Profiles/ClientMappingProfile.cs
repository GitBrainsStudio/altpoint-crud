using AutoMapper;

using ALTPOINT_CRUD.Domain.Entities;
using ALTPOINT_CRUD.Application.Dtos.Responses;

namespace ALTPOINT_CRUD.Infrastructure.AutoMapper.Profiles
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<ClientDto, Client>();
        }
    }
}

using ALTPOINT_CRUD.Application.Contracts;
using ALTPOINT_CRUD.Application.Dtos.Responses;
using ALTPOINT_CRUD.Domain.Entities;

namespace ALTPOINT_CRUD.Infrastructure.AutoMapper.Mappers
{
    public class ClientMapper : IClientMapper
    {
        public ClientDto AsDto(Client entity)
        {
            return new ClientDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Patronymic = entity.Patronymic,
                IsDeleted = entity.IsDeleted
            };
        }

        public IEnumerable<ClientDto> AsDto(List<Client> entities)
        {
            return entities.Select(e => AsDto(e));
        }
    }
}

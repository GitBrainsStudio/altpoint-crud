using ALTPOINT_CRUD.Application.Dtos.Responses;
using ALTPOINT_CRUD.Domain.Entities;

namespace ALTPOINT_CRUD.Application.Contracts
{
    public interface IClientMapper
    {
        ClientDto AsDto(Client entity);
        IEnumerable<ClientDto> AsDto(List<Client> entities);
    }
}

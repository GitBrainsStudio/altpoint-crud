using ALTPOINT_CRUD.Application.Dtos.Requests;
using ALTPOINT_CRUD.Application.Dtos.Responses;

namespace ALTPOINT_CRUD.Application.Contracts
{
    public interface IClientService
    {
        Task<ClientDto> GetById(Guid id);
        Task<ClientDto> Create(CreateClientDto dto);
        Task<ClientDto> Update(Guid id, UpdateClientDto dto);
        Task<ClientDto> Delete(Guid id);
    }
}

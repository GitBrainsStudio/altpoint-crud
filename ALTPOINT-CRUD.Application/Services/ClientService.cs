using ALTPOINT_CRUD.Application.Contracts;
using ALTPOINT_CRUD.Application.Dtos.Requests;
using ALTPOINT_CRUD.Application.Dtos.Responses;
using ALTPOINT_CRUD.Application.Exceptions;
using ALTPOINT_CRUD.Domain.Contracts;
using ALTPOINT_CRUD.Domain.Entities;

namespace ALTPOINT_CRUD.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientMapper _clientMapper;
        public ClientService(
            IClientRepository clientRepository,
            IClientMapper clientMapper)
        {
            _clientRepository = clientRepository;
            _clientMapper = clientMapper;
        }

        public async Task<ClientDto> Create(CreateClientDto clientCreateDto)
        {
            var client = new Client(
                clientCreateDto.Name,
                clientCreateDto.Surname,
                clientCreateDto.Patronymic
                );

            await _clientRepository.Create(client);
            return _clientMapper.AsDto(client);
        }

        public async Task<ClientDto> GetById(Guid id)
        {
            var client = await _clientRepository.GetBy(id);

            if (client is null)
            {
                throw new EntityNotFoundException();
            }

            return _clientMapper.AsDto(client);
        }

        public async Task<ClientDto> Update(Guid id, UpdateClientDto? dto)
        {
            var client = await _clientRepository.GetBy(id);

            if (client is null)
            {
                throw new EntityNotFoundException();
            }

            if (dto is null || dto.Id is null)
            {
                client.Delete();
            }
            else
            {
                client.Update(
                dto.Name,
                dto.Surname,
                dto.Patronymic);
            }

            client = await _clientRepository.Update(client);

            return _clientMapper.AsDto(client);
        }


        public async Task<ClientDto> Delete(Guid id)
        {
            var client = await _clientRepository.GetBy(id);

            if (client is null)
            {
                throw new EntityNotFoundException();
            }

            client.Delete();

            client = await _clientRepository.Update(client);

            return _clientMapper.AsDto(client);
        }
    }
}

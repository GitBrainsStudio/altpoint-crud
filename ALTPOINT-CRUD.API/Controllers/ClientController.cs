using Microsoft.AspNetCore.Mvc;

using ALTPOINT_CRUD.Application.Contracts;
using ALTPOINT_CRUD.Application.Dtos.Requests;
using ALTPOINT_CRUD.Application.Dtos.Responses;
using ALTPOINT_CRUD.API.Attributes;

namespace ALTPOINT_CRUD.API.Controllers
{
    [ApiController]
    [Route("clients")]
    [ValidateModel]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IPaginationService<ClientDto> _paginationService;
        public ClientController(
            IClientService clientService,
            IPaginationService<ClientDto> paginationService)
        {
            _clientService = clientService;
            _paginationService = paginationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPagination([FromQuery] GetPaginationDto dto)
        {
            var outputDto = await _paginationService.Get(dto);
            return Ok(outputDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientDto dto)
        {
            return Ok(await _clientService.Create(dto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dto = await _clientService.GetById(id);
            return Ok(dto);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateClientDto? dto)
        {
            return Ok(await _clientService.Update(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _clientService.Delete(id));
        }
    }
}

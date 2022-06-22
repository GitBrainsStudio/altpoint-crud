using ALTPOINT_CRUD.Application.Dtos.Requests;
using ALTPOINT_CRUD.Application.Dtos.Responses;

namespace ALTPOINT_CRUD.Application.Contracts
{
    public interface IPaginationService<T> where T : class
    {
        Task<PaginationDto<T>> Get(GetPaginationDto dto);
    }
}

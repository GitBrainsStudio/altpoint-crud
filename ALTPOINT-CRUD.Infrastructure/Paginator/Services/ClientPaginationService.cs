using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using ALTPOINT_CRUD.Application.Contracts;
using ALTPOINT_CRUD.Application.Dtos.Responses;
using ALTPOINT_CRUD.Infrastructure.EntityFramework.Contexts;
using ALTPOINT_CRUD.Application.Dtos.Requests;
using ALTPOINT_CRUD.Application.Enums;
using ALTPOINT_CRUD.Domain.Entities;
using ALTPOINT_CRUD.Application.Consts;

namespace ALTPOINT_CRUD.Infrastructure.Paginator.Services
{
    public class ClientPaginationService : IPaginationService<ClientDto>
    {
        private readonly DataBaseContext _dbContext;
        private readonly IClientMapper _clientMapper;
        public ClientPaginationService(
            DataBaseContext dbContext,
            IClientMapper clientMapper)
        {
            _dbContext = dbContext;
            _clientMapper = clientMapper;
        }

        public async Task<PaginationDto<ClientDto>> Get(GetPaginationDto inputDto)
        {
            var query = _dbContext.Clients.AsQueryable();

            Expression<Func<Client, object>> sortExpr = inputDto.sortBy switch
            {
                ClientSortType.Name => c => c.Name,
                ClientSortType.Surname => c => c.Surname,
                ClientSortType.Patronymic => c => c.Patronymic,
                _ => c => c.Name
            };

            var isNull = Expression.Lambda<Func<Client, bool>>(
               Expression.Equal(sortExpr.Body, Expression.Constant(null)), sortExpr.Parameters);

            query = inputDto.sortDir == SortDirectionType.Asc
                ? query.OrderBy(isNull).ThenBy(sortExpr)
                : query.OrderBy(isNull).ThenByDescending(sortExpr);

            if (!string.IsNullOrWhiteSpace(inputDto.search))
            {
                query = query
                    .Where(c => c.Name.Contains(inputDto.search));
            }

            var res = await query.ToListAsync();

            var total = await query.CountAsync();

            query = query
               .Skip(inputDto.limit * (inputDto.page - 1))
               .Take(inputDto.limit);

            var items = await query.ToListAsync();

            return new PaginationDto<ClientDto>()
            {
                Limit = inputDto.limit,
                Page = inputDto.page,
                Total = total,
                Data = _clientMapper.AsDto(items)
            };
        }
    }
}

using ALTPOINT_CRUD.Application.Enums;

namespace ALTPOINT_CRUD.Application.Dtos.Requests
{
    public class GetPaginationDto
    {
        public int Page { get; set; }

        public int Limit { get; set; }

        public string? SortBy { get; set; }

        public SortDirectionType SortDir { get; set; }

        public string? Search { get; set; }
    }
}

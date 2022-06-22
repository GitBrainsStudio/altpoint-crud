namespace ALTPOINT_CRUD.Application.Dtos.Responses
{
    public class PaginationDto<T> where T : class
    {
        public int Limit { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}

namespace ALTPOINT_CRUD.Domain.Contracts
{
    public interface ICreatable
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime? CreatedAt { get; set; }
    }
}

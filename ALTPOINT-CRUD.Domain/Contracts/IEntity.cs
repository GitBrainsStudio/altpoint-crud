namespace ALTPOINT_CRUD.Domain.Contracts
{
    public interface IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        Guid Id { get; set; }
    }
}

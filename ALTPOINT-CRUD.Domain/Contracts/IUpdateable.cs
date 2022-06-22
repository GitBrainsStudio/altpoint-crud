namespace ALTPOINT_CRUD.Domain.Contracts
{
    public interface IUpdateable
    {
        /// <summary>
        /// Дата обновления
        /// </summary>
        DateTime? UpdatedAt { get; set; }
    }
}

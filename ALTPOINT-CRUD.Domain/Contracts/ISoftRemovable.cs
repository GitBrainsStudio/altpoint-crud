namespace ALTPOINT_CRUD.Domain.Contracts
{
    public interface ISoftRemovable
    {
        /// <summary>
        /// Статус удаления
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Дата удаления
        /// </summary>
        public DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Удалить
        /// </summary>
        public void Delete();
    }
}

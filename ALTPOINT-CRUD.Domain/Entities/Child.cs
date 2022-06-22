using ALTPOINT_CRUD.Domain.Contracts;

namespace ALTPOINT_CRUD.Domain.Entities
{
    /// <summary>
    /// Доменная сущность: Ребёнок
    /// </summary>
    public class Child : IEntity
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string? SurName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        public string? Dob { get; set; }
    }
}

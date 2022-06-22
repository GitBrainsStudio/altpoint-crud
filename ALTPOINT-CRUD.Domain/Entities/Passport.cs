using ALTPOINT_CRUD.Domain.Contracts;

namespace ALTPOINT_CRUD.Domain.Entities
{
    /// <summary>
    /// Доменная сущность: паспорт
    /// </summary>
    public class Passport : IEntity, ICreatable, IUpdateable, ISoftRemovable
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Серия
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Кем выдан
        /// </summary>
        public string Giver { get;set; }

        /// <summary>
        /// Дата выдачи
        /// </summary>
        public DateTime DateIssued { get;}

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

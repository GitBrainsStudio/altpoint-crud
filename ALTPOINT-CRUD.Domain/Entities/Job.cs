using ALTPOINT_CRUD.Domain.Contracts;
using ALTPOINT_CRUD.Domain.Enums;

namespace ALTPOINT_CRUD.Domain.Entities
{
    /// <summary>
    /// Доменная сущность: Работа
    /// </summary>
    public class Job : IEntity, ICreatable, IUpdateable, ISoftRemovable
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Тип работы
        /// </summary>
        public JobTypes? Type { get; set; }

        /// <summary>
        /// Дата трудоустройства
        /// </summary>
        public DateTime? DateEmp { get; set; }

        /// <summary>
        /// Дата увольнения
        /// </summary>
        public DateTime? DateDismissal { get; set; }

        /// <summary>
        /// Доход в месяц
        /// </summary>
        public int MonIncomde { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string TIN { get; set; }

        /// <summary>
        /// Фактический адрес
        /// </summary>
        public Address? FactAddress { get; set; }

        /// <summary>
        /// Юридический адрес
        /// </summary>
        public Address? JurAddress { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string? PhoneNumber { get; set; }

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

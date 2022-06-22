using ALTPOINT_CRUD.Domain.Contracts;

namespace ALTPOINT_CRUD.Domain.Entities
{
    /// <summary>
    /// Доменная сущность: Адрес
    /// </summary>
    public class Address : IEntity, ICreatable, IUpdateable, ISoftRemovable
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string? ZipCode { get; set; }

        /// <summary>
        /// Страна
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// Регион
        /// </summary>
        public string? Region { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string? House { get; set; }

        /// <summary>
        /// Номер квартиры
        /// </summary>
        public string? Apartment { get; set; }

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

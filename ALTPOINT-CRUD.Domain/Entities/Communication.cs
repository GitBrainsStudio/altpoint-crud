using ALTPOINT_CRUD.Domain.Contracts;
using ALTPOINT_CRUD.Domain.Enums;

namespace ALTPOINT_CRUD.Domain.Entities
{
    public class Communication : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public CommunicationTypes Type { get; set; }

        /// <summary>
        /// Значение средства связи
        /// </summary>
        public string Value { get; set; }
    }
}

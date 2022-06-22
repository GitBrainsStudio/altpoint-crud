using System.ComponentModel.DataAnnotations.Schema;

using ALTPOINT_CRUD.Domain.Contracts;
using ALTPOINT_CRUD.Domain.Enums;

namespace ALTPOINT_CRUD.Domain.Entities
{
    /// <summary>
    /// Доменная сущность: Клиент
    /// </summary>
    public class Client : IEntity, ICreatable, IUpdateable, ISoftRemovable
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime? Dob { get; set; }

        /// <summary>
        /// Дети
        /// </summary>
        public List<Child> Children { get; set; }

        /// <summary>
        /// Идентификаторы документов
        /// </summary>
        public List<string> DocumentIds 
            => (List<string>)Passport.Select(c => c.Id.ToString());

        /// <summary>
        /// Паспорт
        /// </summary>
        public List<Passport>? Passport { get; set; }

        /// <summary>
        /// Адрес проживания
        /// </summary>
        public Address? LivingAddress { get; set; }

        /// <summary>
        /// Трудоустройство
        /// </summary>
        public List<Job> Jobs { get; set; }

        /// <summary>
        /// Стаж на текущем месте работы
        /// </summary>
        public int CurWorkExp { get; set; }

        /// <summary>
        /// Тип образования
        /// </summary>
        public EducationTypes TypeEducation { get; set; }

        /// <summary>
        /// Суммарный доход в месяц c масштабом (scale) = 2
        /// </summary>
        public int MonIncome { get; set; }

        /// <summary>
        /// Суммарный расход в месяц c масштабом (scale) = 2
        /// </summary>
        public int MonExpenses { get; set; }

        /// <summary>
        /// Средства связи
        /// </summary>
        public List<Communication> Communications { get; set; }

        public Client(
            string name,
            string surname,
            string patronymic)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }

        public void Delete()
        {
            IsDeleted = true;
            DeletedAt = DateTime.Now;
        }

        public void Update(
            string name,
            string surname,
            string patronymic)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }
    }
}
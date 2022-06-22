using System.ComponentModel.DataAnnotations;

namespace ALTPOINT_CRUD.Application.Dtos.Requests
{
    public class CreateClientDto
    {
        [Required(ErrorMessage = "Для создания клиента имя обязательно")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Для создания клиента отчество обязательно")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Для создания клиента фамилия обязательно")]
        public string Patronymic { get; set; }
    }
}

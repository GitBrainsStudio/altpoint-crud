﻿namespace ALTPOINT_CRUD.Application.Dtos.Requests
{
    public class UpdateClientDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
    }
}

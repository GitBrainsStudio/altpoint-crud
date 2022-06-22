using ALTPOINT_CRUD.Domain.Entities;

namespace ALTPOINT_CRUD.Domain.Contracts
{
    public interface IClientRepository
    {
        /// <summary>
        /// Получить клиента по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Client> GetBy(Guid id);

        /// <summary>
        /// Создать клиента
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        Task<Client> Create(Client client);

        /// <summary>
        /// Обновить клиента
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        Task<Client> Update(Client client);
    }
}

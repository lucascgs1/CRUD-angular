using System;
using System.Collections.Generic;
using System.Text;
using CRUD.Model;

namespace CRUD.Services.Interfaces
{
    public interface IClienteServices
    {

        /// <summary>
        /// obtem cliente pelo id
        /// </summary>
        /// <param name="id">codigo do cliente</param>
        /// <returns></returns>
        Cliente GetClienteById(long id);

        /// <summary>
        /// obtem todos os clientes
        /// </summary>
        /// <returns></returns>
        IEnumerable<Cliente> GetAllCliente();

        /// <summary>
        /// salva ou atualiza um cliente
        /// </summary>
        /// <param name="cliente">dados do cliente</param>
        void SalvarCliente(Cliente cliente);

        /// <summary>
        /// delte um cliente pelo id
        /// </summary>
        /// <param name="id">codigo do cliente</param>
        void DeleteClienteById(long id);

    }
}

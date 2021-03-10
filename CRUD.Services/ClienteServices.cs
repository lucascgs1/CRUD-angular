using System;
using System.Collections.Generic;
using System.Text;
using CRUD.Data.Interfaces;
using CRUD.Model;
using CRUD.Services.Interfaces;

namespace CRUD.Services
{
    public class ClienteServices : IClienteServices
    {
        public IClienteRepository ClienteRepository { get; set; }

        public ClienteServices(IClienteRepository clienteRepository)
        {
            ClienteRepository = clienteRepository;
        }

        /// <summary>
        /// obtem cliente pelo id
        /// </summary>
        /// <param name="id">codigo do cliente</param>
        /// <returns></returns>
        public Cliente GetClienteById(long id)
        {
            return ClienteRepository.GetById(id);
        }

        /// <summary>
        /// obtem todos os clientes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cliente> GetAllCliente()
        {
            return ClienteRepository.GetAll();
        }

        /// <summary>
        /// salva ou atualiza um cliente
        /// </summary>
        /// <param name="cliente">dados do cliente</param>
        public void SalvarCliente(Cliente cliente)
        {
            ClienteRepository.Save(cliente);
        }

        /// <summary>
        /// delte um cliente pelo id
        /// </summary>
        /// <param name="id">codigo do cliente</param>
        public void DeleteClienteById(long id)
        {
            ClienteRepository.Remove(id);
        }
    }
}
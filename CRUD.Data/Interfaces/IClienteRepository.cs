using CRUD.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Data.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        /// <summary>
        /// obtem um cliente pelo id
        /// </summary>
        /// <param name="id">codigo do cliente</param>
        /// <returns></returns>
        Cliente GetById(long id);

        /// <summary>
        /// delta um cliente pelo id
        /// </summary>
        /// <param name="id">codigo do cliente</param>
        void Remove(long id);

        /// <summary>
        /// salva ou atualiza os dados de um cliente
        /// </summary>
        /// <param name="cliente">dados do cliente</param>
        void Save(Cliente cliente);
    }
}

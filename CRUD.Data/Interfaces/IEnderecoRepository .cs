using CRUD.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Data.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        /// <summary>
        /// obtem todos os enderecos de um usuario
        /// </summary>
        /// <param name="userId">codigo do usuario</param>
        /// <returns></returns>
        IEnumerable<Endereco> GetAllEnderecosByUserId(int userId);

        /// <summary>
        /// salva ou atualiza um endereco
        /// </summary>
        /// <param name="endereco"></param>
        void Save(Endereco endereco);

        /// <summary>
        /// deleter em massa
        /// </summary>
        /// <param name="enderecos">lista de enderecos a ser excluida</param>
        void RemoveRange(IEnumerable<Endereco> enderecos);
    }
}

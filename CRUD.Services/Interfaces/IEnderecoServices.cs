using System;
using System.Collections.Generic;
using System.Text;
using CRUD.Model;

namespace CRUD.Services.Interfaces
{
    public interface IEnderecoServices
    {

        /// <summary>
        /// obtem endereco pelo id
        /// </summary>
        /// <param name="id">codigo do endereco</param>
        /// <returns></returns>
        Endereco GetEnderecoById(int id);

        /// <summary>
        /// Salva ou atualiza um endereco
        /// </summary>
        /// <param name="endereco">dados do endereco</param>
        void SalvarEndereco(Endereco endereco);

        /// <summary>
        /// obtem todos os enderecos
        /// </summary>
        /// <returns></returns>
        IEnumerable<Endereco> GetAllEndereco();

        /// <summary>
        /// obtem uma lista de enderecos pelo id do usuario
        /// </summary>
        /// <param name="userId">codigo do usuario</param>
        /// <returns></returns>
        IEnumerable<Endereco> GetAllEnderecoByUserId(int userId);

        /// <summary>
        /// deleta endereco pelo id
        /// </summary>
        /// <param name="id">codigo do endereco</param>
        void DeleteEnderecoById(int id);
    }
}

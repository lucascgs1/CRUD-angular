using System;
using System.Collections.Generic;
using System.Text;
using CRUD.Data.Interfaces;
using CRUD.Model;
using CRUD.Services.Interfaces;

namespace CRUD.Services
{
    public class EnderecoServices : IEnderecoServices
    {
        #region repostorio
        public IEnderecoRepository EnderecoRepository { get; set; }
        #endregion

        public EnderecoServices(IEnderecoRepository enderecoRepository)
        {
            EnderecoRepository = enderecoRepository;
        }

        /// <summary>
        /// obtem endereco pelo id
        /// </summary>
        /// <param name="id">codigo do endereco</param>
        /// <returns></returns>
        public Endereco GetEnderecoById(int id)
        {
            return EnderecoRepository.GetById(id);
        }

        /// <summary>
        /// Salva ou atualiza um endereco
        /// </summary>
        /// <param name="endereco">dados do endereco</param>
        public void SalvarEndereco(Endereco endereco)
        {
            EnderecoRepository.Save(endereco);
        }

        /// <summary>
        /// obtem todos os enderecos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Endereco> GetAllEndereco()
        {
            return EnderecoRepository.GetAll();
        }

        /// <summary>
        /// obtem uma lista de enderecos pelo id do usuario
        /// </summary>
        /// <param name="userId">codigo do usuario</param>
        /// <returns></returns>
        public IEnumerable<Endereco> GetAllEnderecoByUserId(int userId)
        {
            return EnderecoRepository.GetAllEnderecosByUserId(userId);
        }

        /// <summary>
        /// deleta endereco pelo id
        /// </summary>
        /// <param name="id">codigo do endereco</param>
        public void DeleteEnderecoById(int id)
        {
            EnderecoRepository.Remove(id);
        }
    }


}
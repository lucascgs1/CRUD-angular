using System;
using System.Collections.Generic;
using System.Text;
using CRUD.Data.Interfaces;
using CRUD.Model;
using CRUD.Services.Interfaces;

namespace CRUD.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        #region repositorios
        public IUsuarioRepository UsuarioRepository { get; set; }

        public IEnderecoRepository EnderecoRepository { get; set; }
        #endregion

        public UsuarioServices(IUsuarioRepository usuarioRepository, IEnderecoRepository enderecoRepository)
        {
            UsuarioRepository = usuarioRepository;
            EnderecoRepository = enderecoRepository;
        }

        /// <summary>
        /// obtem todos os usuarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> GetAllUsuario()
        {
            return UsuarioRepository.GetAll();
        }

        /// <summary>
        /// obtem o usuario pelo id
        /// </summary>
        /// <param name="id">codigo do usuario</param>
        /// <returns></returns>
        public Usuario GetUsuarioById(int id)
        {
            return UsuarioRepository.GetUsuarioById(id);
        }

        /// <summary>
        /// Salva ou atualiza um usuario
        /// </summary>
        /// <param name="usuario">dados do usuario</param>
        public void SalvarUsuario(Usuario usuario)
        {
            UsuarioRepository.Save(usuario);

        }

        /// <summary>
        /// deleta um usuario pelo id
        /// </summary>
        /// <param name="id">codigo do usuario</param>
        public void DeleteUsuarioById(int id)
        {
            try
            {
                UsuarioRepository.BeginTransaction();

                EnderecoRepository.RemoveRange(EnderecoRepository.GetAllEnderecosByUserId(id));

                UsuarioRepository.Remove(id);

                UsuarioRepository.CommitTransaction();
            }
            catch (Exception ex)
            {
                UsuarioRepository.RollbackTransaction();

                throw ex;
            }
        }
    }
}
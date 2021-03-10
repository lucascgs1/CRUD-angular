using CRUD.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Data.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        /// <summary>
        /// inicia uma transacao
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// encerra uma transacao
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// encerra uma transacao
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// obtem usuario pelo id
        /// </summary>
        /// <param name="id">codigo do usuario</param>
        /// <returns></returns>
        Usuario GetUsuarioById(int id);

        /// <summary>
        /// salva ou atualiza um usuario
        /// </summary>
        /// <param name="usuario">dados do usuario</param>
        void Save(Usuario usuario);
    }
}

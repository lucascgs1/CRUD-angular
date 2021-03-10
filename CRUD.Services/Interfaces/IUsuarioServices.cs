using System;
using System.Collections.Generic;
using System.Text;
using CRUD.Model;

namespace CRUD.Services.Interfaces
{
    public interface IUsuarioServices
    {

        /// <summary>
        /// obtem todos os usuarios
        /// </summary>
        /// <returns></returns>
        Usuario GetUsuarioById(int id);

        /// <summary>
        /// obtem o usuario pelo id
        /// </summary>
        /// <param name="id">codigo do usuario</param>
        /// <returns></returns>
        void SalvarUsuario(Usuario usuario);

        /// <summary>
        /// Salva ou atualiza um usuario
        /// </summary>
        /// <param name="usuario">dados do usuario</param>
        void DeleteUsuarioById(int id);

        /// <summary>
        /// deleta um usuario pelo id
        /// </summary>
        /// <param name="id">codigo do usuario</param>
        IEnumerable<Usuario> GetAllUsuario();
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using CRUD.Data.Interfaces;
using CRUD.Model;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CRUD.Data
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        private readonly ApplicationDbContext _context;

        public EnderecoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtem todos os enderecos por usuario
        /// </summary>
        /// <param name="userId">Codigo do usuario</param>
        /// <returns></returns>
        public IEnumerable<Endereco> GetAllEnderecosByUserId(int userId)
        {
            return Db.Endereco.Where(e => e.UsuarioId == userId).ToList();
        }

        /// <summary>
        /// Salvar ou atualizar um novo endereco
        /// </summary>
        /// <param name="endereco">dados do endereco</param>
        public void Save(Endereco endereco)
        {

            BeginTransaction();
            if (endereco.EnderecoPrincipal)
            {
                var lstEnderecos = Db.Endereco.Where(e => e.UsuarioId == endereco.UsuarioId);

                foreach (var item in lstEnderecos)
                {
                    item.EnderecoPrincipal = false;
                }

                DbSet.UpdateRange(lstEnderecos);
            }

            if (endereco.Id > 0)
            {
                DbSet.Update(endereco);
            }
            else
                DbSet.Add(endereco);

            CommitTransaction();
        }
    }
}
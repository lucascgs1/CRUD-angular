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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// obtem um cliente pelo id
        /// </summary>
        /// <param name="id">codigo do cliente</param>
        /// <returns></returns>
        public Cliente GetById(long id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// delta um cliente pelo id
        /// </summary>
        /// <param name="id">codigo do cliente</param>
        public void Remove(long id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        /// <summary>
        /// salva ou atualiza os dados de um cliente
        /// </summary>
        /// <param name="cliente">dados do cliente</param>
        public void Save(Cliente cliente)
        {
            if (cliente.Id > 0)
            {
                DbSet.Update(cliente);
            }
            else
                DbSet.Add(cliente);

            Db.SaveChanges();
        }
    }
}
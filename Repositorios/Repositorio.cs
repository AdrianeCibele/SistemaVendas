using Dominios.Entidades;
using Dominios.Repositorio;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Dominios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorios
{
    public abstract class Repositorio<TEntidade> : DbContext, IRepositorio<TEntidade>
        where TEntidade : EntityBase, new()
    {
       protected DbContext Db;
       protected DbSet<TEntidade> DbSetContext;


        public Repositorio(DbContext dbContext)
        {
            Db = dbContext;

            DbSetContext = Db.Set<TEntidade>();
        }

        public void Create(TEntidade Entity)
        {
           if(Entity.Codigo == null)
            {
                DbSetContext.Add(Entity);
            }
            else
            {
                Db.Entry(Entity).State = EntityState.Modified;
            }

            Db.SaveChanges();            
           
        }

        public virtual void Delete(int id)
        {
            var ent = new TEntidade { Codigo = id };
            DbSetContext.Attach(ent);
            DbSetContext.Remove(ent);
            Db.SaveChanges();
        }

        public TEntidade Read(int id)
        {
           return DbSetContext.Where(x => x.Codigo == id).FirstOrDefault();
        }

        public virtual IEnumerable<TEntidade> Read()
        {
           return DbSetContext.AsNoTracking().ToList();
        }
    }
}

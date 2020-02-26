using Microsoft.EntityFrameworkCore;
using SistemaVendas.Dominios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Dominios.Repositorio;
using Repositorios.Contexto;
using System.Linq;

namespace Repositorios.Entidades
{
    public class RepositorioProduto : Repositorio<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(ApplicationDbContext dbContext) : base(dbContext)  {  }


        public override IEnumerable<Produto> Read()
        {
            return DbSetContext.Include(x => x.Categoria).AsNoTracking().ToList();
        }

    }
}

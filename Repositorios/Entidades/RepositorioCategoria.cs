using Microsoft.EntityFrameworkCore;
using SistemaVendas.Dominios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Dominios.Repositorio;
using Repositorios.Contexto;

namespace Repositorios.Entidades
{
    public class RepositorioCategoria : Repositorio<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoria(ApplicationDbContext dbContext) : base(dbContext)  {  }

    }
}

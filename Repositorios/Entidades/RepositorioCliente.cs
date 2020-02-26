using Microsoft.EntityFrameworkCore;
using SistemaVendas.Dominios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Dominios.Repositorio;
using Repositorios.Contexto;

namespace Repositorios.Entidades
{
    public class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(ApplicationDbContext dbContext) : base(dbContext)  {  }

    }
}

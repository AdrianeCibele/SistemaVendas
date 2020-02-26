using SistemaVendas.Dominios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominios.Repositorio
{
   public  interface IRepositorioProduto : IRepositorio<Produto>
    {
        //As Classes de Produtos são obrigadas a implementar esse método pelo motivo de relacionamento externos
        new IEnumerable<Produto> Read();

    }
}

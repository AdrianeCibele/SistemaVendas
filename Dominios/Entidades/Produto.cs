using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominios.Entidades;

namespace SistemaVendas.Dominios.Entidades
{
    public class Produto : EntityBase
    {

        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public decimal Valor { get; set; }
        public Categoria Categoria { get; set; }

        public ICollection<VendaProdutos> Vendas { get; set; }

        [ForeignKey("Categoria")]
        public int CodigoCategoria { get; set; }


    }
}

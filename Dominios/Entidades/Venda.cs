using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominios.Entidades;

namespace SistemaVendas.Dominios.Entidades
{
    public class Venda : EntityBase
    {

        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public Cliente Cliente { get; set; }

        public ICollection<VendaProdutos> Produtos { get; set; }



        [ForeignKey("Cliente")]
        public int CodigoCliente { get; set; }





    }
}

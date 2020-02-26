using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominios.Entidades;

namespace SistemaVendas.Dominios.Entidades
{
    public class Cliente : EntityBase
    {
                
   
        public string Nome { get; set; }
        public string CNPJ_CPF { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        public ICollection<Venda> Vendas { get; set; }


    }
}

using SistemaVendas.Dominios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominios.Interfaces
{
   public  interface IServicoCRUD<TEntidade> where TEntidade: class
    {
        IEnumerable<TEntidade> Listagem();

        void Cadastrar(TEntidade TEntidade);

        TEntidade CarregarRegistro(int id);

        void Excluir(int id);
    }
}

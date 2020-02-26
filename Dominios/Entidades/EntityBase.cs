using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominios.Entidades
{
    public class EntityBase
    {
        [Key]
        public int? Codigo { get; set; }

    }
}

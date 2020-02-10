using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class PedidoModel
    {

        public Guid IdSabor { get; set; }

        public Guid IdTamanho { get; set; }

        public List<Guid> Adicionais { get; set; }

    }
}

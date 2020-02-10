using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Adicional
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; }

        public int MinutosAdicionais { get; set; } = 0;

        public decimal ValorAdicionais { get; set; } = 0;

        public ICollection<PedidoAdicional> PedidoAdicionais { get; set; } = new HashSet<PedidoAdicional>();
    }
}

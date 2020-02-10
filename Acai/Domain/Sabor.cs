using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Sabor
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; }

        public int MinutosAdicionais { get; set; } = 0;

        public ICollection<Pedido> Pedidos { get; set; } = new HashSet<Pedido>();
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Pedido
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("IdSabor")]
        public virtual Sabor Sabor { get; set; }
        public Guid IdSabor { get; set; }

        [ForeignKey("IdTamanho")]
        public virtual Tamanho Tamanho { get; set; }
        public Guid IdTamanho { get; set; }

        public ICollection<PedidoAdicional> PedidoAdicionais { get; set; } = new HashSet<PedidoAdicional>();

        public int TempoTotal { get; set; }

        public decimal ValorTotal { get; set; }

    }
}

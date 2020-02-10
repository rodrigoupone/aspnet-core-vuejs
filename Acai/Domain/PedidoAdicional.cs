using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class PedidoAdicional
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("IdPedido")]
        public virtual Pedido Pedido { get; set; }
        public Guid IdPedido { get; set; }

        [ForeignKey("IdAdicional")]
        public virtual Adicional Adicional { get; set; }
        public Guid IdAdicional { get; set; }

    }
}

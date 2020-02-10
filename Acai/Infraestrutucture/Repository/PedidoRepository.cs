using Infraestrutucture.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestrutucture.Repository
{
    public class PedidoRepository : GenericDataRepository<Domain.Pedido>
    {
        public PedidoRepository(AcaiContext acaiContext) : base(acaiContext)
        {
        }
    }
}

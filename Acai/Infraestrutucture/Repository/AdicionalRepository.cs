using Infraestrutucture.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestrutucture.Repository
{
    public class AdicionalRepository : GenericDataRepository<Domain.Adicional>
    {
        public AdicionalRepository(AcaiContext acaiContext) : base(acaiContext)
        {
        }
    }
}

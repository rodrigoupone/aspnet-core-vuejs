using Infraestrutucture.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestrutucture.Repository
{
    public class SaborRepository : GenericDataRepository<Domain.Sabor>
    {
        public SaborRepository(AcaiContext acaiContext) : base(acaiContext)
        {
        }
    }
}

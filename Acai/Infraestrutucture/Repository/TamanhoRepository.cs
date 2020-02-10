using Infraestrutucture.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestrutucture.Repository
{
    public class TamanhoRepository : GenericDataRepository<Domain.Tamanho>
    {
        public TamanhoRepository(AcaiContext acaiContext) : base(acaiContext)
        {
        }
    }
}

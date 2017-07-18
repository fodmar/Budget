using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ObjectModel
{
    public class CorrelationIdProvider : ICorrelationIdProvider
    {
        public CorrelationIdProvider()
        {
            this.CurrentId = Guid.NewGuid();
        }

        public Guid CurrentId { get; set; }
    }
}

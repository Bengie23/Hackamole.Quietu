using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackamole.Quietu.SharedKernel.Events.configuration
{
    public class BusProviderConfiguration
    {
        public string Endpoint { get; set; }
        public string Producer { get; set; }
        public string Topic { get; set; }
    }
}

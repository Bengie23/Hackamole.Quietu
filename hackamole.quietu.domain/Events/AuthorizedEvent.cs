using Hackamole.Quietu.SharedKernel.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackamole.Quietu.Domain.Events
{
    public class AuthorizedEvent : IDomainEvent
    {
        public string PrincipalId { get; set; }
        public bool Authorized { get; set; }
        public string ProductCode { get; set; }
    }
}

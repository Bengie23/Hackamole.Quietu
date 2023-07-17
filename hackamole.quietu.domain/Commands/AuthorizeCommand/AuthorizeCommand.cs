using hackamole.quietu.SharedKernel.Interfaces.Commands;
using Hackamole.Quietu.SharedKernel.Commands;

namespace hackamole.quietu.domain.Commands;

public class AuthorizeCommand : BaseCommand, ICommand  {

    public string PrincipalId { get; set; }

    public string? ProductCode { get; set; }
}
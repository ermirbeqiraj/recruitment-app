using MediatR;

namespace Domain.Services.Commands
{
    public sealed class RegisterClientCommand : IRequest
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
    }
}

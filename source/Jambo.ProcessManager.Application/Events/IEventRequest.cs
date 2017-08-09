using MediatR;

namespace Jambo.ProcessManager.Application.Events
{
    public interface IEventRequest<T> : IRequest
    {
        T Event { get; }
    }
}

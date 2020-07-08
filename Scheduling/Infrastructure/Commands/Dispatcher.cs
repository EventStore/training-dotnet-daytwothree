using System.Threading.Tasks;
using Scheduling.EventSourcing;

namespace Scheduling.Infrastructure.Commands
{
    public class Dispatcher
    {
        private readonly CommandHandlerMap _map;

        public Dispatcher(CommandHandlerMap map) =>
            _map = map;

        public Task Dispatch(object command, CommandMetadata metadata)
        {
            var handler = _map.Get(command);

            return handler(command, metadata);
        }
    }
}
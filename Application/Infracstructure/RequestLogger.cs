using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Infracstructure {
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest> {
        //private readonly ILogger _logger;
        private string mes;
        public RequestLogger(/*ILogger<TRequest> logger*/) {
            mes = "Logger constructor";
        }

        public Task Process(TRequest request, CancellationToken cancellationToken) {
            var name = typeof(TRequest).Name;

            // TODO: Add User Details

            //_logger.LogInformation("Northwind Request: {Name} {@Request}", name, request);

            return Task.CompletedTask;
        }
    }
}

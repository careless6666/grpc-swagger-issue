using System.Threading.Tasks;
using Greet;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger _logger;

        public GreeterService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GreeterService>();
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Sending hello to {request.NamePeka}");
            return Task.FromResult(new HelloReply { MessageNo = $"Hello {request.NamePeka}" });
        }

        public override Task<HelloReply> SayHelloFrom(HelloRequestFrom request, ServerCallContext context)
        {
            _logger.LogInformation($"Sending hello to {request.NameAt} from {request.FromTest}");
            return Task.FromResult(new HelloReply { MessageNo = $"Hello {request.NameAt} from {request.FromTest}" });
        }
    }
}
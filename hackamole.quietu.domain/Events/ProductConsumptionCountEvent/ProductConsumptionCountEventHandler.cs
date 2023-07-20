using Hackamole.Quietu.Domain.Interfaces;
using KafkaFlow;
using KafkaFlow.TypedHandler;
using Microsoft.Extensions.Logging;

namespace Hackamole.Quietu.Domain.Events.ProductConsumptionCountEvent
{
    public class ProductConsumptionCountEventHandler : IMessageHandler<AuthorizedEvent>
    {
        private IProductRepository productRepository;
        private ILogger<ProductConsumptionCountEventHandler> logger;

        public ProductConsumptionCountEventHandler()
        {
            //IProductRepository productRepository
            //this.productRepository = productRepository;
            //this.logger = logger;
        }

        public Task Handle(IMessageContext context, AuthorizedEvent message)
        {
            //logger.LogInformation("Message Received", DateTimeOffset.Now);

            //return new Task(() => { 
            //    productRepository.IncreaseProductUsageCount(message.ProductCode); 
            //});

            throw new NotImplementedException();
        }
    }
}

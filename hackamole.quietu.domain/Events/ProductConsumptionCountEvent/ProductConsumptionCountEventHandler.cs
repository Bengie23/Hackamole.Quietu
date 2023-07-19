using Hackamole.Quietu.Domain.Interfaces;
using KafkaFlow;
using KafkaFlow.TypedHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackamole.Quietu.Domain.Events.ProductConsumptionCountEvent
{
    public class ProductConsumptionCountEventHandler : IMessageHandler<AuthorizedEvent>
    {
        private IProductRepository productRepository;

        public ProductConsumptionCountEventHandler()
        {
            //IProductRepository productRepository
            //this.productRepository = productRepository;
        }

        public Task Handle(IMessageContext context, AuthorizedEvent message)
        {
            Console.WriteLine("Mensaje Recibido");

            //return new Task(() => { 
            //    productRepository.IncreaseProductUsageCount(message.ProductCode); 
            //});

            return null;
        }
    }
}

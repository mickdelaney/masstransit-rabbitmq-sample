using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Messages;
using MassTransit;

namespace Service
{
    public class CustomerService
    {
        readonly IServiceBus _bus;

        public CustomerService()
        {
            _bus = Bus.Instance;
        }

        public void Start()
        {
            _bus.SubscribeHandler<CreateCustomerMessage>(msg => CreateCustomer(msg));

            Console.WriteLine("Starting....");
        }

        public void Stop()
        {

            Console.WriteLine("Stopping....");
        }

        public void CreateCustomer(CreateCustomerMessage command)
        {
            Console.WriteLine("Creating Customer: {0} {1} with Id: {2}", command.FirstName, command.LastName, command.Id);
        }
    }
}

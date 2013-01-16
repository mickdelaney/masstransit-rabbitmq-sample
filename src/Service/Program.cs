using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassTransit;
using Topshelf;

namespace Service
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.UseRabbitMqRouting();
                sbc.ReceiveFrom("rabbitmq://localhost/sample.customerservices");
            });

            var cfg = HostFactory.New(c => {

                c.SetServiceName("Sample.CustomerServices");
                c.SetDisplayName("Sample.CustomerServices");
                c.SetDescription("Sample.CustomerServices");

                //c.BeforeStartingServices(s => {});

                c.Service<CustomerService>(a =>
                {
                    a.ConstructUsing(service => new CustomerService());
                    a.WhenStarted(o => o.Start());
                    a.WhenStopped(o => o.Stop());
                });

            });

            try
            {
                cfg.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}

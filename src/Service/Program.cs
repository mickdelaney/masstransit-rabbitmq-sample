using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassTransit;
using Topshelf;
using Topshelf.Configuration.Dsl;

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
                sbc.ReceiveFrom("rabbitmq://localhost/elevate");
            });

            var cfg = HostFactory.New(c => {

                c.SetServiceName("ElevateServices");
                c.SetDisplayName("ElevateServices");
                c.SetDescription("ElevateServices");

                //c.BeforeStartingServices(s => {});

                c.Service<CvParserService>(a =>
                {
                    a.ConstructUsing(service => new CvParserService());
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

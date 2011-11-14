using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Messages;
using MassTransit;

namespace Service
{
    public class CvParserService
    {
        readonly IServiceBus _bus;

        public CvParserService()
        {
            _bus = Bus.Instance;
        }

        public void Start()
        {
            _bus.SubscribeHandler<ParseCvMessage>(msg => ParseCv(msg.S3Key));

            Console.WriteLine("Starting....");
        }

        public void Stop()
        {

            Console.WriteLine("Stopping....");
        }

        public void ParseCv(string name)
        {
            Console.WriteLine(name);
        }
    }
}

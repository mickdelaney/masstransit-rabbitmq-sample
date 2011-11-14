using System;

namespace Domain.Messages
{
    public class ParseCvMessage
    {
        public string S3Key { get; set; }
        public Guid ContractorId { get; set; }
    }
}
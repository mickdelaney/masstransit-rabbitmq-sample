using System;

namespace Domain.Messages
{
    public sealed class CreateCustomerMessage
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
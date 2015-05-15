using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IG.Validations
{
    public class ValidationMessage
    {
        public Guid id { get; private set; }
        public string Message { get; set; }

        public int MessageId { get; set; }

        public MessageType MessageType { get; set; }

        public string Source { get; set; }

        public ValidationMessage()
        {
            id = Guid.NewGuid();
        }

        public ValidationMessage(string message, int messageId, string source, MessageType messageType = MessageType.Error)
             : this()
        {
            MessageType = messageType;
            MessageId = messageId;
            Message = message;
            Source = source;
        }


        public static ValidationResult Create()
        {
            return new ValidationResult();
        }


    }
}

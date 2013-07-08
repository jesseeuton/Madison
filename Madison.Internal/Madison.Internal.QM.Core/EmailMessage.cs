using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Madison.Internal.QM.Core
{
    public class EmailMessage
    {
        public int TransactionId { get; set; }
        public bool Passed { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SendTo { get; set; }
        public string SendFrom { get; set; }

        public EmailMessage() { }
    }
}

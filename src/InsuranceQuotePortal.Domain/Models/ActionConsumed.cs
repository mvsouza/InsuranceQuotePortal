using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceQuotePortal.Domain.Models
{
    public class ActionConsumed
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public int TimesHited { get; set; }
    }
}

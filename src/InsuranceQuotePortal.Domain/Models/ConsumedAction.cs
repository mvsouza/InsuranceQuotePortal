using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceQuotePortal.Domain.Models
{
    public class ConsumedAction
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public int TimesHited { get;private set; }
        public ConsumedAction()
        {
            TimesHited = 1;
        }
        public int IncrementTimesHited()
        {
            return ++TimesHited;
        }
    }
}

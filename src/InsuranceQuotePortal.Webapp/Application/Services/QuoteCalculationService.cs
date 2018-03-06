using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceQuotePortal.Domain.Models;

namespace InsuranceQuotePortal.Application.Services
{
    public class QuoteCalculationService : IQuoteCalculationService 
    {
        private IMapper _mapper;
        public QuoteCalculationService(IMapper mapper) {
            _mapper = mapper;
        }
        public decimal Calculate<Tv, Tm>(Tv viewModel) where Tm : IInsurable {
            IInsurable model = _mapper.Map<Tm>(viewModel);  
            return model.CalculateQuote();
        }

    }
}

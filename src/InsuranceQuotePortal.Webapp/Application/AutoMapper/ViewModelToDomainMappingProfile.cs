using AutoMapper;
using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Webapp.Application.Models;

namespace InsuranceQuotePortal.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {

            CreateMap<FarmViewModel, Farm>();
            CreateMap<HouseViewModel, House>();
            CreateMap<VehicleViewModel, Car>();
            CreateMap<VehicleViewModel, Motorcycle>();
        }
    }
}

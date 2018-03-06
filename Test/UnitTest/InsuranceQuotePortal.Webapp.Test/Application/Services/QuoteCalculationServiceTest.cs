using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InsuranceQuotePortal.Application.AutoMapper;
using InsuranceQuotePortal.Application.Services;
using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Webapp.Application.Models;
using Xunit;

namespace InsuranceQuotePortal.Webapp.Test.Application.Services
{

    public class QuoteCalculationServiceTest : IDisposable
    {
        public IMapper _mapper;
        public QuoteCalculationServiceTest()
        {
            Mapper.Initialize(m => m.AddProfile<ViewModelToDomainMappingProfile>());
            _mapper = Mapper.Instance;
        }

        public object CarViewModel { get; private set; }

        public static IEnumerable<object[]> CarQuotes =>
            new List<object[]>
            {
                new object[] { 1000m, DateTime.Now.Year, 60m },
                new object[] { 1000m, DateTime.Now.Year-1,110m },
                new object[] { 1000m, DateTime.Now.Year-20, 150m }
            };

        [Theory]
        [MemberData(nameof(CarQuotes))]
        public void Quote_Calculate_Car(decimal price, int year, decimal result)
        {
            var service = new QuoteCalculationService(_mapper);
            var newCar = new VehicleViewModel()
            {
                Year = year,
                Price = price
            };
            Assert.Equal(service.Calculate<VehicleViewModel, Car>(newCar), result);
        }
        
        public static IEnumerable<object[]> MotorcycleQuotes =>
            new List<object[]>
            {
                new object[] { 1000m, DateTime.Now.Year, 60m },
                new object[] { 1000m, DateTime.Now.Year-1,110m },
                new object[] { 1000m, DateTime.Now.Year-20, 250m }
            };

        [Theory]
        [MemberData(nameof(MotorcycleQuotes))]
        public void Quote_Calculate_Motorcycle(decimal price, int year, decimal result)
        {
            var service = new QuoteCalculationService(_mapper);
            var newMotorcycle = new VehicleViewModel()
            {
                Year = year,
                Price = price
            };
            Assert.Equal(service.Calculate<VehicleViewModel, Motorcycle>(newMotorcycle), result);
        }


        public static IEnumerable<object[]> FarmQuotes =>
            new List<object[]>
            {
                new object[] { 1000m, 100m, 3.0m },
                new object[] { 1000m, 200m, 4.0m },
                new object[] { 1300m, 100m, 3.9m }
            };

        [Theory]
        [MemberData(nameof(FarmQuotes))]
        public void Quote_Calculate_Farm(decimal price, decimal squareMeter, decimal result)
        {
            var service = new QuoteCalculationService(_mapper);
            var newFarm = new FarmViewModel()
            {
                SquareMeter = squareMeter,
                Price = price
            };
            Assert.Equal(service.Calculate<FarmViewModel, Farm>(newFarm), result);
        }
        public static IEnumerable<object[]> HouseQuotes =>
            new List<object[]>
            {
                new object[] { 1000m, 20m },
                new object[] { 1300m, 26m }
            };

        [Theory]
        [MemberData(nameof(HouseQuotes))]
        public void Quote_Calculate_House(decimal price, decimal result)
        {
            var service = new QuoteCalculationService(_mapper);
            var newHouse = new HouseViewModel()
            {
                Price = price
            };
            Assert.Equal(service.Calculate<HouseViewModel, House>(newHouse), result);
        }

        public void Dispose()
        {
            Mapper.Reset();
        }
    }
}

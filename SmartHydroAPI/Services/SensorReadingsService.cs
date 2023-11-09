using Microsoft.EntityFrameworkCore;
using SmartHydroAPI.Models;
using SmartHydroAPI.ViewModels;

namespace SmartHydroAPI.Services
{
    public class SensorReadingsService
    {
        private readonly SmartHydroDbContext _context;
        public SensorReadingsService()
        {
            _context = new();
        }

        public async Task<bool> Save(SensorReadingsViewModel viewModel)
        {
            var model = ConvertToModel(viewModel);
            _context.SensorReadings.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SaveRange(List<SensorReadingsViewModel> viewModel)
        {
            var model = viewModel.Select(x => new SensorReading
            {
                Temperature = x.Temperature,
                Humidity = x.Humidity,
                Ec = x.Ec,
                Ph = x.Ph,
                LightIntensity = x.LightIntensity,
                WaterFlow = x.WaterFlow,
            }).ToList();

            _context.SensorReadings.AddRange(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<SensorReadingsViewModel>> Get()
        {
            return await _context.SensorReadings.Select(x => new SensorReadingsViewModel
            {
                Temperature = x.Temperature,
                Humidity = x.Humidity,
                Ec = x.Ec,
                Ph = x.Ph,
                LightIntensity = x.LightIntensity,
                WaterFlow = x.WaterFlow,
            }).ToListAsync();
        }

        public SensorReading ConvertToModel(SensorReadingsViewModel viewModel)
        {
            return new SensorReading
            {
                Temperature = viewModel.Temperature,
                Humidity = viewModel.Humidity,
                Ec = viewModel.Ec,
                Ph = viewModel.Ph,
                LightIntensity = viewModel.LightIntensity,
                WaterFlow = viewModel.WaterFlow,
            };
        }
    }
}

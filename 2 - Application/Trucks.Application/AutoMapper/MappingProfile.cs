using AutoMapper;
using Trucks.Application.ViewModels;
using Trucks.Domain.Models;

namespace Trucks.Application.AutoMapper
{
    /// <summary>
    /// Auto mapper profile to convert objects.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Model -> ViewModel
            CreateMap<Truck, TruckViewModel>();

            // ViewModel -> Model
            CreateMap<TruckViewModel, Truck>();
        }
    }
}

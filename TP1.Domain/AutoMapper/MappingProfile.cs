using AutoMapper;
using TP1.Domain.Models;
using TP1.Domain.Models.DTO;

namespace RestfullAPI.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ReverseMap();

            CreateMap<Team, TeamDTO>()
                .ReverseMap();

            CreateMap<Requisition, RequisitionDTO>()
                .ReverseMap();

            CreateMap<RequisitionProduct, RequisitionProductDTO>()
                .ReverseMap();

            CreateMap<Person, PersonDTO>()
                .ReverseMap();

            CreateMap<PersonCovid, PersonCovidDTO>()
                .ReverseMap();
        }
    }
}

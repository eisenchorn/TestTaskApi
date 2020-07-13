using System.Linq;
using AutoMapper;
using DataAccessLayer.Entities;
using TestTaskApi.Dto;

namespace TestTaskApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyBaseDto>();
            CreateMap<Company, CompanyDto>()
                .ForMember(x => x.Managers,
                    opt =>
                        opt.MapFrom(x => x.CompanyManagers.Select(cm => cm.Manager)
                            .ToList()))
                .ForMember(x => x.CompanyContactInfo,
                    opt =>
                        opt.MapFrom(companyDto => companyDto.ContactInfo));

            CreateMap<Country, CountryDto>();

            CreateMap<Manager, ManagerBaseDto>();

            CreateMap<Manager, ManagerDto>()
                .ForMember(x => x.Companies, opt =>
                      opt.MapFrom(man => man.CompanyManagers.Select(x => x.Company).ToList()));

            CreateMap<Payer, PayerDto>();

            CreateMap<ContactInfo, ContactInfoDto>();
        }
    }
}
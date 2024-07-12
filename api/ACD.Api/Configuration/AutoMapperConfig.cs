using ACD.Api.Dto;
using ACD.Domain.Models;
using AutoMapper;
using Profile = AutoMapper.Profile;



namespace ACD.Api.Configuration;



/// <summary>
/// Configuration class for AutoMapper profiles. 
/// This class defines the mappings between domain entities and their corresponding DTOs (Data Transfer Objects).
/// </summary>
public class AutoMapperConfig : Profile
{

    /// <summary>
    /// Constructor of AutoMapperConfig
    /// </summary>
    public AutoMapperConfig()
    {

        CreateMap<BalanceServiceProvider, BalanceServiceProviderDTO>();
        CreateMap<BalanceServiceProviderDTO, BalanceServiceProvider>();

        //Mapping for getting data from the web
        CreateMap<BalanceServiceProviderResponse, BalanceServiceProviderDTO>()
            .ForMember(dest => dest.BspCode, opt => opt.MapFrom(src => src.brpCode))
            .ForMember(dest => dest.BspName, opt => opt.MapFrom(src => src.brpName))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.country))
            .ForMember(dest => dest.ValidityStart, opt => opt.MapFrom(src => src.validityStart))
            .ForMember(dest => dest.ValidityEnd, opt => opt.MapFrom(src => src.validityEnd))
            .ForMember(dest => dest.BusinessId, opt => opt.MapFrom(src => src.businessId))
            .ForMember(dest => dest.CodingScheme, opt => opt.MapFrom(src => src.codingScheme));

    }

}
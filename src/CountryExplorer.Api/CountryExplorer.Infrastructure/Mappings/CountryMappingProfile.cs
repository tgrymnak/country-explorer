using AutoMapper;
using CountryExplorer.Domain.Models;
using Rest = RestCountries.Client.Models;

namespace CountryExplorer.Infrastructure.Mappings
{
	internal class CountryMappingProfile : Profile
	{
		public CountryMappingProfile()
		{
			CreateMap<Rest.Country, Country>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Common))
				.ForMember(dest => dest.Currencies, opt => opt.MapFrom(src => src.Currencies.Select(e => new Currency(e.Key, e.Value.Name, e.Value.Symbol))))
				.ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.Languages.Select(e => new Language(e.Key, e.Value))))
				.ForMember(dest => dest.Flag, opt => opt.MapFrom(src => src.Flags.Svg))
				.ForMember(dest => dest.Map, opt => opt.MapFrom(src => src.Maps != null ? src.Maps.GoogleMaps : string.Empty));
		}
	}
}
